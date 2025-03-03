<template>
    <div id="head">
        <div id="content">
            <div id="statusHeader">Администрирование сайта</div>
            <div id="href"><a href="./ClientPage">Ваш сайт  &#x1F517</a></div>
            <div id="profile">Kunjut</div>
        </div>
    </div>
</template>

<script>

</script>

<style>
    #head {
        font-family: 'Open Sans', sans-serif;
        position: absolute;
        width: 100%;
        height: 50px;
        border-bottom: solid 1px #b9b9b9;
    }

    #content {
        position: relative;
    }

    #statusHeader {
        position: absolute;
        padding: 16px 16px 16px 25px;
    }

    #href {
        position: absolute;
        padding-top: 14px;
        left: 260px;
    }

    #profile {
        position: absolute;
        right: 50px;
        padding: 16px;
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