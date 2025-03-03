<template>
    <div class="itemModal" v-if="show" @click.stop="hideModal">
        <div class="modalContent" @click.stop>
            <form method="post" @submit.prevent>
                <h1>Создание товара</h1>
                <div class="string">
                    <input id="nameString" type="text" placeholder="Наименование товара" />
                </div>
                <div class="string">
                    <input id="priceString" type="text" placeholder="Цена за единицу" />
                </div>
                <div class="string">
                    <input id="categoryString" type="text" placeholder="Категория товара" />
                </div>
                <div class="button">
                    <input type="submit" id="addItemButton" value="Добавить" @click="clickAddItem"/>
                </div>
            </form>
        </div>

        <div id="resultsAddItem"></div>
    </div>
</template>

<script>
    export default {
        name: "itemContent",
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
            clickAddItem() {
                let message = {
                    name: $('#nameString').val(),
                    price: $('#priceString').val(),
                    category: $('#categoryString').val(),
                };

                $.ajax({
                    type: "POST",
                    url: "/AdminPage/AddItem",
                    data: JSON.stringify(message),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function () {
                        document.getElementById("resultsAddItem").style.display = "block";
                        document.getElementById("resultsAddItem").style.color = "black";
                        $("#resultsAddItem").html('Загрузка...');
                    },
                    success: function () {
                        document.getElementById("resultsAddItem").style.color = "green";
                        document.getElementById("nameString").value = "";
                        document.getElementById("priceString").value = "";
                        document.getElementById("categoryString").value = "";
                        $('#resultsAddItem').html('Успех!');
                    },
                    error: function (xhr) {
                        document.getElementById("resultsAddItem").style.color = "red";
                        document.getElementById("resultsAddItem").classList.add('shake');

                        $('#resultsAddItem').html('Данные введены некорректно!');

                        setTimeout(function () {
                            document.getElementById("resultsAddItem").classList.remove('shake');
                        }, 600);
                    }
                });

                return false;
            }
        }
    }
</script>

<style scoped>
    .itemModal {
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
        min-width: 500px;
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

    #resultsAddItem {
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