<template>
    <transition name="fade-show">
        <div v-show="visible"
             class="modal-wrap">
            <div class="modal-main"
                 :style="style">
                <div class="modal-head">
                    {{title}}
                </div>
                <div class="modal-body">
                    <slot></slot>
                </div>
                <div class="modal-foot">
                    <slot name="modal-foot">
                        <button @click="handled"
                                class="btn">
                            确定
                        </button>
                        <button @click="close"
                                class="btn">
                            取消
                        </button>
                    </slot>
                </div>
            </div>
        </div>
    </transition>
</template>
<script>
export default {
    name: 'modal',
    props: {
        title: {
            type: String,
            default: '我是模态框'
        },
        visible: {
            type: Boolean,
            default: false
        },
        width: {
            type: String,
            default: '280px'
        },
        height:{
            type:String,
            default:'auto'
        },
        top: {
            type: String,
            default: '20%'
        }
    },
    methods: {
        close() {
            this.$emit('close')
        },
        handled() {
            this.$emit('handled')
        }
    },
    computed: {
        style() {
            return { maxWidth: this.width, top: this.top,height:this.auto }
        }
    }
}
</script>
<style>
.modal-wrap {
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    position: fixed;
    overflow: hidden;
    z-index: 999;
    background-color: rgba(0, 0, 0, 0.3);
}

.modal-main {
    position: absolute;
    left: 50%;
    transform: translateX(-50%);
    background: #fff;
    border-radius: 2px;
    box-shadow: 0 1px 3px rgba(0, 0, 0, .3);
    box-sizing: border-box;
}

.close {
    position: relative;
    float: right;
    right: -1.5rem;
    top: -1.5rem;
    cursor: pointer;
}

.modal-head {
    padding: 1rem;
    font-size: 1.2rem;
}

.modal-body {
    padding: 1rem;
}
.modal-foot::before{
    clear: both;
}
.modal-foot {
    float: right;
    padding: 0 1rem;
}

.modal-foot button {
    float: right;
    margin: 0 0 1rem 0.5rem;
}
</style>