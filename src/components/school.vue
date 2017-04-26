<template>
    <div>
        <div class="box">
            <table class="hover">
                <thead>
                    <tr>
                        <!--<th width="40px">编号</th>-->
                        <th>作品名</th>
                        <th width="50px">抽签号</th>
                        <th width="70px">操作</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(result,key) of results">
                        <!--<td>{{key+1}}</td>-->
                        <td>{{result.sortName}}</td>
                        <td>{{result.randomID}}</td>
                        <td>
                            <button class="btn" type="button" v-if="!result.randomID"
                            @click="produceRandom(result.sortID)"
                            >抽签</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <modal title="抽签结果"
               :visible="randomSate"
               @handled='randomSate = false'>
            <span>{{resultNum}}</span>
            <button @click="handled"
                    class="btn"
                    slot="modal-foot">
                确定
            </button>
        </modal>
        <loading :visible="loading"></loading>
    </div>
</template>
<script>
    import {
        sort
    } from '@/API/index'
    export default {
        namme: 'shool',
        data() {
            return {
                results: [],
                loading: false,
                resultNum: Number,
                randomSate: false
            }
        },
        created() {
            this.getList()
        },
        methods: {
            getList() {
                this.loading = true
                sort.getSortByUserID().then(m => {
                    this.results = m.body
                    this.loading = false
                }).catch((m) => {
                    this.loading = false
                })
            },
            produceRandom(id) {
                this.loading = true
                this.randomSate = true
                sort.produceRandom(id).then((m) => {
                    this.resultNum = m.body.msg
                    this.loading = false
                    this.getList()
                })
            },
            handled() {
                this.randomSate = false
            }
        }
    }
</script>