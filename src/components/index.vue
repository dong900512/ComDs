<template>
    <div class="main box">
        <div style="width:50%;text-align:center;"
             v-for="(group,key) of groups">
            <button class="group"
                    :class="[key%2==0 ? 'group-left' :'group-right']"
                    @click="navDetail(group.groupID)">
                {{group.groupName}}
            </button>
        </div>
        <loading :visible="loading"></loading>
    </div>
</template>
<script>
    import {
        group
    } from '@/API/index'
    export default {
        name: 'index',
        data() {
            return {
                groups: [],
                loading: false
            }
        },
        created() {
            this.getList()
        },
        methods: {
            getList() {
                this.loading = true
                group.get().then(m => {
                    this.groups = m.body
                    this.loading = false
                })
            },
            navDetail(id) {
                this.$router.push({
                    name: 'groupDetail',
                    params: {
                        id: id
                    }
                })
            }
        }
    }
</script>
<style>
    .group {
        padding: 3rem 1rem;
        width: 95%;
        border: none;
        background-color: #14679e;
        color: #fefefe;
        cursor: pointer;
        margin: 1rem 0;
    }
    
    .group-left {
        float: left;
    }
    
    .group-right {
        float: right;
    }
</style>