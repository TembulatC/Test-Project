<template>
    <div class="clientModal" v-if="show" @click.stop="hideModal">
        <div class="modalContent" @click.stop>
            <form method="post" @submit.prevent>
                <h1>Создание клиента</h1>
                <div class="string">
                    <input id="nameString" type="text" placeholder="Логин" />
                </div>
                <div class="string">
                    <input id="passwordString" type="password" placeholder="Пароль" />
                </div>
                <div class="button">
                    <input type="submit" id="addClientButton" value="Добавить" @click="clickAddClient"/>
                </div>
            </form>
        </div>

        <div id="resultsAddCLient"></div>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        name: "clientContent",
        props: {
            show: {
                type: Boolean,
                default: false
            }
        },
        methods: {
            hideModal() {
                this.$emit('update:show', false)
            },

            clickAddClient() {
                let message = {
                    login: $('#nameString').val(),
                    password: $('#passwordString').val(),
                };

                $.ajax({
                    type: "POST",
                    url: "/AdminPage/AddClient",
                    data: JSON.stringify(message),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function () {
                        document.getElementById("resultsAddCLient").style.display = "block";
                        document.getElementById("resultsAddCLient").style.color = "black";
                        $("#resultsAddCLient").html('Загрузка...');
                    },
                    success: function () {
                        document.getElementById("resultsAddCLient").style.color = "green";
                        document.getElementById("nameString").value = "";
                        document.getElementById("passwordString").value = "";
                        $('#resultsAddCLient').html('Успех!');
                    },
                    error: function (xhr) {
                        document.getElementById("resultsAddCLient").style.color = "red";
                        document.getElementById("resultsAddCLient").classList.add('shake');
                        if (xhr.status == 400) {
                            $('#resultsAddCLient').html('Данные введены некорректно!');
                        }
                        else if (xhr.status == 409) {
                            $('#resultsAddCLient').html('Пользователь уже существует!');
                        }
                        setTimeout(function () {
                            document.getElementById("resultsAddCLient").classList.remove('shake');
                        }, 600);
                    }
                });   
            },
        }
    }
</script>

<style scoped>
    .clientModal {
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        background-color: rgba(0, 0, 0, 0.5);
        position: fixed;
        display: flex;
    }

    .modalContent {
        margin: auto;
        background-color: white;
        border-radius: 5px;
        min-height: 50px;
        width: 500px;
    }

    h1 {
        padding-bottom: 30px;
    }

    form {
        padding: 25px;
    }

    .string {
        padding-bottom: 20px;
    }

    .string input {
        height: 40px;
        width: 100%;
        border: none;
        outline: none;
        border: 1.5px solid #666666;
        border-radius: 5px;
        transition: all 0.5s;
    }

        .string input:hover {
            border-color: rgb(38, 123, 120);
        }

        .string input:focus {
            border-color: rgb(83, 189, 166);
        }

    .button input {
        position: relative;
        left: 350px;
        border: none;
        outline: none;
        border-radius: 5px;
        height: 30px;
        width: 100px;
        background-color: rgb(38, 123, 120);
        color: white;
        font-weight: bold;
        transition: all 0.5s;
    }

        .button input:hover {
            background-color: rgb(83, 189, 166);
        }

    .string input[type=text], .string input[type=password] {
        padding-left: 10px;
    }

    #resultsAddCLient {
        display: none;
        position: absolute;
        top: 70%;
        left: 50%;
        transform: translate(-50%, -50%);
        background: #fff;
        border-radius: 10px;
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