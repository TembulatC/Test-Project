<template>
    <div id="sidebar">
        <div class="default">
            <div class="elements">
                <div id="border">
                    <div id="menuElement">
                        <button @click="openNav"><span id="name">Test</span><img src="../../img/showSidebar.png" /></button>
                    </div>
                </div>

                <div class="nav">
                    <div class="e1" id="navElement">
                        <button type="button" id="itemButton"><img src="../../img/items.png" /><span class="animate" id="spanElement">Товары</span></button>
                    </div>
                    <div class="e2" id="navElement2">
                        <button type="button" id="clientButton"><img src="../../img/clients.png" /><span class="fix animate" id="spanElement1">Пользователи</span></button>
                    </div>
                    <div class="e3" id="navElement3">
                        <button type="button" id="orderButton"><img src="../../img/orders.png" /><span class="animate" id="spanElement2">Заказы</span></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="main">
        <adminHeader />
        <content />
    </div>

</template>

<style>
    #sidebar {
        font-family: 'Open Sans', sans-serif;
        position: fixed;
        color: white;
        width: 50px;
        background-color: #004250;
        height: 100%;
        z-index: 1;
        transition: 0.5s;
        overflow-x: hidden;
    }

    #sidebar img {
        filter: invert(1);
    }

    .elements div {
        transition: all 0.5s;
    }

    .elements .nav div {
        position: fixed;
    }

        .elements .nav div:hover, #border:hover {
            background-color: rgb(127, 255, 212, 0.3);
        }

    .e1 {
        top: 70px;
    }

    .e2 {
        top: 120px;
    }

    .e3 {
        top: 170px;
    }

    .elements div button {
        outline: none;
        border: none;
        background-color: rgb(127, 255, 212, 0.3);
        display: flex;
        justify-content: center;
        align-items: center;
        width: 30px;
        height: 30px;
        border-radius: 5px;
        transition: all 0.5s;
    }

        .elements div button:hover {
            background-color: rgb(127, 255, 212, 0.5);
        }

    #border {
        position: fixed;
        width: 50px;
        height: 50px;
        border-bottom: 1px solid;
        border-color: rgb(127, 255, 212, 0.5);
    }

    #menuElement {
        position: fixed;
        left: 0;     
        padding: 10px;
    }

    .nav {
        position: absolute;
        top: 50px;
    }
    
    .nav div {
        padding: 10px;
    }

    #name {
        font-weight: bold;
        font-size: 35px;
        left: -140px;
        opacity: 0;
        width: 100px;
        line-height: 50px;
        position: fixed;
        color: white;
        transition: 0.5s;
    }
    .animate {
        opacity: 0;
        width: 100px;
        line-height: 50px;
        left: -140px;
        font-weight: bold;
        font-size: 17px;
        position: fixed;
        color: white;
        transition: 0.5s;
    }

    .fix {
        width: 160px;
    }

    @keyframes showBlock {
        0% {
            opacity: 0;
        }

        100% {
            opacity: 1;
        }
    }

    @keyframes hideBlock {
        0% {
            opacity: 1;
        }

        100% {
            opacity: 0;
        }
    }

    .showBlock {
        animation: showBlock 1s linear forwards;
    }

    .hideBlock {
        animation: hideBlock 0.2s linear forwards;
    }

    #main {
        left: 0;
        position: relative;
        width: 100%;
        transition: all 0.5s;
    }
</style>

<script>
    import AdminHeader from "./AdminHeader.vue"
    import Content from "./Content.vue"
    import axios from 'axios'
    export default {
        data() {
            return {
                flag: true,
            }
        },
        components: {
            AdminHeader,
            Content,
        }, 
        name: 'Sidebar',
        methods: {
            openNav() {
                if (this.flag) {
                    document.getElementById("sidebar").style.width = "250px";
                    document.getElementById("menuElement").style.left = "200px";
                    document.getElementById("border").style.width = "250px";
                    document.getElementById("navElement").style.width = "250px";
                    document.getElementById("navElement2").style.width = "250px";
                    document.getElementById("navElement3").style.width = "250px";
                    document.getElementById("name").style.left = "20px";
                    document.getElementById("spanElement").style.left = "40px";
                    document.getElementById("spanElement1").style.left = "40px";
                    document.getElementById("spanElement2").style.left = "40px";
                    document.getElementById("main").style.left = "200px";
                    document.getElementById("profile").style.right = "200px";
                    document.getElementById("divTabel").style.width = "calc(100% - 500px)";
                    document.getElementById("search").style.right = "250px";
                    setTimeout(function () {
                        document.getElementById("spanElement").classList.add('showBlock');
                        document.getElementById("spanElement1").classList.add('showBlock');
                        document.getElementById("spanElement2").classList.add('showBlock');
                        document.getElementById("name").classList.add('showBlock');
                        document.getElementById("spanElement").classList.remove('hideBlock');
                        document.getElementById("spanElement1").classList.remove('hideBlock');
                        document.getElementById("spanElement2").classList.remove('hideBlock');
                        document.getElementById("name").classList.remove('hideBlock');
                    }, 500)
                }
                else {
                    document.getElementById("spanElement").classList.add('hideBlock');
                    document.getElementById("spanElement1").classList.add('hideBlock');
                    document.getElementById("spanElement2").classList.add('hideBlock');
                    document.getElementById("name").classList.add('hideBlock');
                    document.getElementById("spanElement").classList.remove('showBlock');
                    document.getElementById("spanElement1").classList.remove('showBlock');
                    document.getElementById("spanElement2").classList.remove('showBlock');
                    document.getElementById("name").classList.remove('showBlock');
                    setTimeout(function () {
                        document.getElementById("sidebar").style.width = "50px";
                        document.getElementById("menuElement").style.left = "0px";
                        document.getElementById("border").style.width = "50px";
                        document.getElementById("navElement").style.width = "50px";
                        document.getElementById("navElement2").style.width = "50px";
                        document.getElementById("navElement3").style.width = "50px";
                        document.getElementById("name").style.left = "-140px";
                        document.getElementById("spanElement").style.left = "-140px";
                        document.getElementById("spanElement1").style.left = "-140px";
                        document.getElementById("spanElement2").style.left = "-140px";
                        document.getElementById("main").style.left = "0px";
                        document.getElementById("profile").style.right = "0px";
                        document.getElementById("divTabel").style.width = "calc(100% - 250px)";
                        document.getElementById("search").style.right = "0px";
                    }, 200)
                    
                }

                this.flag = !this.flag;
            },
        }
    }
</script>