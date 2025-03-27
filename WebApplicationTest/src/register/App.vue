<template>
    <div class="window">
        <div class="authWindow">
            <h1>Добро пожаловать!</h1>

            <form method="post">
                <div class="string">
                    <input id="nameString" type="text" placeholder="Логин" />
                </div>
                <div class="string">
                    <input id="passwordString" type="password" placeholder="Пароль" />
                </div>
                <div class="string" id="emailVision">
                    <input id="emailString" type="email" placeholder="Почта" />
                </div>
                <div class="string" id="phoneVision">
                    <input id="phoneString" type="tel" placeholder="Телефон"/>
                </div>
                <div class="button" id="_registerButton">
                    <input type="submit" id="registerButton" value="ЗАРЕГИСТРИРОВАТЬСЯ" />
                </div>
                <div class="button" id="_registerButton2">
                    <input type="submit" id="registerButton2" value="ЗАРЕГИСТРИРОВАТЬСЯ" />
                </div>
                <div class="button button2" id="registerPhoneButton">
                    <input type="button" @click="switchPhoneNumber" value="ЧЕРЕЗ ТЕЛЕФОН" />
                </div>
                <div class="button button2" id="registerEmailButton">
                    <input type="button" @click="switchEmail" value="ЧЕРЕЗ EMAIL" />
                </div>
            </form>

            <div class="redirect">
                <a href="./Auth">Назад</a>
            </div>
        </div>
    </div>

    <div id="results"></div>
</template>

<script>
    export default {
        name: 'App',
        methods: {
            switchPhoneNumber() {
                document.getElementById("phoneVision").style.display = "block";
                document.getElementById("registerPhoneButton").style.display = "none";
                document.getElementById("registerEmailButton").style.display = "block";
                document.getElementById("emailVision").style.display = "none";
                document.getElementById("_registerButton").style.display = "none";
                document.getElementById("_registerButton2").style.display = "block";
            },

            switchEmail() {
                document.getElementById("phoneVision").style.display = "none";
                document.getElementById("registerPhoneButton").style.display = "block";
                document.getElementById("registerEmailButton").style.display = "none";
                document.getElementById("emailVision").style.display = "block";
                document.getElementById("_registerButton").style.display = "block";
                document.getElementById("_registerButton2").style.display = "none";
            }
        },
    }
</script>

<style>
    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
    }

    body {
        background-color: #f2f2f2;
    }

    .window {
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        background: #fff;
        border-radius: 10px;
        box-shadow: 0 5px 10px 0px rgba(0, 0, 0, 0.1);
        font-family: 'Open Sans', sans-serif;
    }

    .authWindow {
        text-align: center;
        padding: 40px 35px;
        font-weight: bold;
    }

    form {
        padding: 20px 20px 0 20px;
    }

        form div {
            margin: 30px 0 30px 0;
        }

    input {
        width: 100%;
        height: 40px;
        border: none;
        outline: none;
    }

    .string input {
        border-bottom: 2px solid #666666;
        transition: all 0.5s;
    }

        .string input:hover {
            border-bottom-color: #004250;
        }

        .string input:focus {
            border-bottom-color: #004250;
        }

    #emailVision {
        display: block;
    }

    #phoneVision {
        display: none;
    }

    #_registerButton {
        display: block;
    }

    #_registerButton2 {
        display: none;
    }

    #registerPhoneButton {
        display: block;
    }

    #registerEmailButton {
        display: none;
    }

    .button {
        margin: 30px 0 15px 0;
    }

    .button2 {
        margin: 15px 0 30px 0;
    }

    .button input {
        font-weight: bold;
        border-radius: 10px;
        color: white;
        background-color: #004250;
        transition: all 0.5s;
    }

        .button input:hover {
            transform: scale(1.03);
        }

    .redirect {
        font-family: Poppins-Regular;
        font-size: 13px;
    }

        .redirect a {
            color: #666666;
            text-decoration: none;
            transition: all 0.5s;
            margin: 0 0 0 5px;
        }

            .redirect a:hover {
                color: #004250;
            }

    #results {
        display: none;
        position: absolute;
        top: 80%;
        left: 50%;
        transform: translate(-50%, -50%);
        background: #fff;
        border-radius: 10px;
        box-shadow: 0 5px 10px 0px rgba(0, 0, 0, 0.1);
        font-family: 'Open Sans', sans-serif;
        padding: 20px;
        font-weight: bold;
    }

    @keyframes shake {
        10%, 90% {
            transform: translateX(-1px) translate(-50%, -50%);
        }

        20%, 80% {
            transform: translateX(1px) translate(-50%, -50%);
        }

        30%, 50%, 70% {
            transform: translateX(-1px) translate(-50%, -50%);
        }

        40%, 60% {
            transform: translateX(1px) translate(-50%, -50%);
        }
    }

    .shake {
        animation: shake 0.5s cubic-bezier(0.68, -0.55, 0.27, 1.55) both;
    }
</style>