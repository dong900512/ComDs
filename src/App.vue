<template>
  <div id="app" class="main-box">
    <transition name="slide-show">
      <router-view></router-view>
    </transition>
    <div class="box box-rc">版权所有*西华师范大学计算机学院<br/>Powered by LiuFang</div>
    <foot-bar></foot-bar>
  </div>
</template>

<script>
    export default {
        name: 'app',
    }
</script>