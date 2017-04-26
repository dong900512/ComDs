<template>
    <div>
        <div class="box">
            <table class="hover">
                <thead>
                    <tr>
                        <th width="40px">编号</th>
                        <th>作品名</th>
                        <th width="50px">抽签号</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(result,key) of results">
                        <td>{{key+1}}</td>
                        <td>{{result.sortName}}</td>
                        <td>{{result.randomID}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
        </modal>
        <loading :visible="loading"></loading>
    </div>
</template>
<script>
    import {
        sort
    } from '@/API/index'
    export default {
        name: 'groupDetail',
        data() {
            return {
                results: [],
                loading: false,
                routeId: Number,
            }
        },
        created() {
            this.getList()
        },
        methods: {
            getList() {
                if (this.$route.params.id == undefined) {
                    alert("参数错误")
                    this.$router.push({
                        path: '/'
                    })
                } else {
                    this.loading = true
                    this.routeId = this.$route.params.id
                    sort.getSortByGroupID(this.routeId).then(m => {
                        this.results = m.body
                        this.loading = false
                    }).catch((m) => {
                        console.log(m)
                        this.loading = false
                    })
                }
            }
        }
    }
</script>