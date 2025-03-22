<template>
    <div class="clientModal" v-if="show" @click.stop="hideModal">
        <div class="modalContent" @click.stop>
            <form @submit.prevent>
                <h1>Изменение клиента</h1>
                <div class="string">
                    <input id="nameString" type="text" placeholder="Логин" />
                </div>
                <div class="string">
                    <input id="passwordString" type="password" placeholder="Пароль" />
                </div>
                <div class="string">
                    <input id="discountString" type="number" placeholder="Скидка"/>
                </div>
                <div class="button">
                    <input type="submit" id="addClientButton" value="Изменить" @click="clickUpdateClient" />
                </div>
            </form>
        </div>

        <div id="resultsUpdateCLient"></div>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        name: "updateClientContent",
        props: {
            show: {
                type: Boolean,
                default: false
            },

            check: {
                type: String
            }
        },
        methods: {
            hideModal() {
                this.$emit('update:show', false)
            },

            clickUpdateClient() {
                let updateClientData = {
                    login: $('#nameString').val(),
                    password: $('#passwordString').val(),
                    code: this.check,
                    discount: $('#discountString').val()
                };

                $.ajax({
                    type: "PUT",
                    url: "/AdminPage/UpdateClient",
                    data: JSON.stringify(updateClientData),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function () {
                        document.getElementById("resultsUpdateCLient").style.display = "block";
                        document.getElementById("resultsUpdateCLient").style.color = "black";
                        $("#resultsUpdateCLient").html('Загрузка...');
                    },
                    success: function () {
                        document.getElementById("resultsUpdateCLient").style.color = "green";
                        $('#resultsUpdateCLient').html('Успех!');
                    },
                    error: function () {
                        document.getElementById("resultsUpdateCLient").style.color = "red";
                        document.getElementById("resultsUpdateCLient").classList.add('shake');

                        $('#resultsUpdateCLient').html('Ошибка!');

                        setTimeout(function () {
                            document.getElementById("resultsUpdateCLient").classList.remove('shake');
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

    .string input[type=text], .string input[type=password], .string input[type=number] {
        padding-left: 10px;
    }

    #resultsUpdateCLient {
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