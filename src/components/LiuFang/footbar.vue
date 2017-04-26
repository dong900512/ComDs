<template>
    <div class="main-box bar-fixed">
        <div class="box box-nowrap">
            <div class="text-center" @click="navgative(item.name)" v-for="item in items">
                <button class="btn" type="button">{{item.title}}</button>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'footBar',
        data() {
            return {
                items: [{
                    title: '赛程总览',
                    name: 'index'
                }, {
                    title: '学校总览',
                    name: 'school'
                }]
            }
        },
        methods: {
            navgative(name) {
                this.$router.push({
                    name,
                    name
                })
            }
        }
    }
</script>
<style scoped>
    .bar-fixed {
        right: 0;
        bottom: 0;
        left: 0;
        position: fixed;
        z-index: 1
    }
    
    .btn {
        font-size: 1.2rem;
        width: 100%;
    }
</style>