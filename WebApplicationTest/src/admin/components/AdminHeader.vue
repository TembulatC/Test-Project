<template>
    <div id="head">
        <div id="statusHeader">Администрирование сайта</div>
        <div id="href"><a href="./ClientPage">Ваш сайт  &#x1F517</a></div>
        <div id="profile">Kunjut</div>
    </div>
</template>

<script>

</script>

<style>
    #head {
        position: relative;
        font-family: 'Open Sans', sans-serif;
        width: 100%;
        height: 50px;
        border-bottom: solid 1px #b9b9b9;
    }

    #statusHeader {
        position: absolute;
        left: 100px;
        top: 16px;
    }

    #href {
        position: absolute;
        left: 350px;
        top: 14px;
    }

    #profile {
        position: absolute;
        right: 0px;
        padding: 16px 50px;
        transition: all 0.5s;
    }

    #profile a {
        font-weight: bold;
    }

    a {
        color: #0094ff;
        text-decoration: none;
    }

        a:hover {
            color: #008080;
            transition: 0.5s;
        }
</style>

<script>
    export default {
        name: 'AdminHeader'
    }
</script>