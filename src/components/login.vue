<template>
    <div>
        <form>
            <div class="box box-rc padding-tb">
                用户登录
            </div>
            <div class="box">
                <div class="box margin-tb">
                    <div style="width:20%;text-align:right;height: 2.4375rem;line-height:2.4375rem;">
                        用户名:
                    </div>
                    <div style="width:5%;"></div>
                    <div style="width:70%;">
                        <input class="form-control"
                               v-model="user.userName"
                               @keyup.enter="login"
                               placeholder="请输入用户名..." />
                    </div>
                    <div style="width:5%;"></div>
                </div>
                <div class="box margin-tb">
                    <div style="width:20%;text-align:right;height: 2.4375rem;line-height:2.4375rem;">
                        密码:
                    </div>
                    <div style="width:5%;"></div>
                    <div style="width:70%;">
                        <input type="password" class="form-control"
                               v-model="user.userPwd"
                               @keyup.enter="login"
                               placeholder="请输入密码..." />
                    </div>
                    <div style="width:5%;"></div>
                </div>
            </div>
            <div class="box">
                <div style="width:25%">
                </div>
                <div style="width:75%;color:red;">
                    {{errorMsg}}
                </div>
            </div>
            <div class="box margin-tb">
                <div style="width:25%">
                </div>
                <div style="width:20%;">
                    <button type="button"
                            @click="login"
                            class="btn">登录</button>
                </div>
            </div>
            <loading :visible="loading"></loading>
        </form>
    </div>
</template>
<script>
    import {
        user
    } from '@/API/index'
    export default {
        name: 'login',
        data() {
            return {
                user: {
                    userName: '',
                    userPwd: ''
                },
                errorMsg: '',
                toRoute: '',
                loading: false
            }
        },
        created() {
            let path = this.$route.params.path
            this.toRoute = path ? path : '/'
        },
        methods: {
            login() {
                if (this.user.userName == '' || this.user.userPwd == '')
                    this.errorMsg = '用户名或者密码不能为空'
                else {
                    this.loading = true
                    user.login(this.user).then((m) => {
                        if (m.body.state == '500')
                            this.errorMsg = "用户或者密码错误"
                        else {
                            this.$store.dispatch('login', {
                                name: this.user.userName,
                                token: m.body.access_token,
                            })
                            this.$router.push({
                                path: this.toRoute
                            })
                        }
                        this.loading = false
                    })
                }
            }
        }
    }
</script>
<style>
    .form-control {
        display: block;
        -webkit-box-sizing: border-box;
        box-sizing: border-box;
        width: 90%;
        height: 2.4375rem;
        margin: 0 0 1rem;
        padding: 0.5rem;
        border: 1px solid #cacaca;
        border-radius: 0;
        background-color: #fefefe;
        -webkit-box-shadow: inset 0 1px 2px rgba(10, 10, 10, 0.1);
        box-shadow: inset 0 1px 2px rgba(10, 10, 10, 0.1);
        font-family: inherit;
        font-size: 1rem;
        font-weight: normal;
        color: #0a0a0a;
        -webkit-transition: border-color 0.25s ease-in-out, -webkit-box-shadow 0.5s;
        transition: border-color 0.25s ease-in-out, -webkit-box-shadow 0.5s;
        transition: box-shadow 0.5s, border-color 0.25s ease-in-out;
        transition: box-shadow 0.5s, border-color 0.25s ease-in-out, -webkit-box-shadow 0.5s;
        -webkit-appearance: none;
    }
</style>