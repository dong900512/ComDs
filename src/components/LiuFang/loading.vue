<template>
    <transition name="fade-show">
        <div v-show="visible"
             class="modal-wrap">
             <slot>加载中...</slot>
        </div>
    </transition>
</template>
<script>
export default {
    name: 'loading',
    props: {
        visible: {
            type: Boolean,
            default: false
        },
    },
}
</script>
<style scoped>
.modal-wrap {
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    position: fixed;
    overflow: hidden;
    z-index: 999;
    background-color: rgba(0, 0, 0, 0.3);
    color: white;
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>