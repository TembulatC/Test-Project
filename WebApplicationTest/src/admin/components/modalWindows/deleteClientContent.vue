<template>
    <div class="clientModal" v-if="show" @click.stop="hideModal">
        <div class="modalContent" @click.stop>
            <form @submit.prevent>
                <h1>Удаление клиента</h1>
                <div class="text">Вы действительно хотите удалить выбранного клиента?</div>
                <div class="button">
                    <input type="submit" id="addClientButton" value="Удалить" @click="clickDeleteClient"/>
                </div>
            </form>
        </div>
    </div>

    <div id="resultsDeleteCLient"></div>
</template>

<script>
    import axios from 'axios'
    export default {
        name: "deleteClientContent",
        props: {
            show: {
                type: Boolean,
                default: false
            },

            check: {
                type: Array
            }
        },
        methods: {
            hideModal() {
                this.$emit('update:show', false)
            },

            clickDeleteClient() {
                var list_codes = { codes: this.check }

                $.ajax({
                    type: "DELETE",
                    url: "/AdminPage/DeleteClient",
                    data: JSON.stringify(list_codes),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function () {
                        document.getElementById("resultsDeleteCLient").style.display = "block";
                        document.getElementById("resultsDeleteCLient").style.color = "black";
                        $("#resultsDeleteCLient").html('Загрузка...');
                    },
                    success: function () {
                        document.getElementById("resultsDeleteCLient").style.color = "green";
                        $('#resultsDeleteCLient').html('Успех!');
                    },
                    error: function () {
                        document.getElementById("resultsDeleteCLient").style.color = "red";
                        document.getElementById("resultsDeleteCLient").classList.add('shake');

                        $('#resultsDeleteCLient').html('Ошибка!');

                        setTimeout(function () {
                            document.getElementById("resultsDeleteCLient").classList.remove('shake');
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

    form {
        padding: 25px;
    }

    .text {
        text-align: center;
        padding: 30px;
        font-size: 17px;
    }

    #resultsDeleteCLient {
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