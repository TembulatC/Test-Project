<template>
    <div id="itemContent">
        <div id="Buttons">
            <h1>Все товары</h1>
            <button id="addButton" @click="itemShowModal">Добавить</button>
            <button type="button" id="delItemButton">Удалить</button>
            <button type="button" id="editItemButton">Изменить</button>
        </div>
    </div>
    <div id="clientContent">
        <div id="Buttons">
            <h1>Все клиенты</h1>
            <button id="addButton" @click="clientShowModal">Добавить</button>
            <button type="button" id="delItemButton">Удалить</button>
            <button type="button" id="editItemButton">Изменить</button>
        </div>

        <div id="search">
            <form method="get" @submit.prevent>
                <label for="showBy" class="label2">Показывать на странице:</label>
                <select id="showBy">
                    <option value="25">25</option>
                    <option value="50">50</option>
                    <option value="100">100</option>
                </select>

                <label for="filterBy">Поиск по:</label>
                <select id="filterBy">
                    <option value="name">Имени</option>
                    <option value="code">Коду</option>
                    <option value="address">Адресу</option>
                    <option value="discount">Скидке</option>
                </select>

                <label for="sortBy" class="label">Сортировка по:</label>
                <select id="sortBy">
                    <option class="byS" value="asc">Возрастанию</option>
                    <option class="byS" value="desc">Убыванию</option>
                </select>

                <input id="searchString" type="search" placeholder="Поиск по имени, коду, адресу или скидке" />
                <button id="searchBtn" type="button" @click="GetClientsByFilter">Найти</button>
            </form>
        </div>

        <div id="divTabel">
            <table>
                <thead>
                    <tr>
                        <th class="col5"><input type="checkbox" name="select" /></th>
                        <th class="col1">Имя</th>
                        <th class="col2">Код</th>
                        <th class="col3">Адрес пункта выдачи</th>
                        <th class="col4">Скидка</th>
                    </tr>
                </thead>
                <tbody>

                    <tr v-for="client in clientsSort">
                        <td class="col5"><input type="checkbox" name="selectAll" /></td>
                        <td class="col1">{{ client.name }}</td>
                        <td class="col2">{{ client.code }}</td>
                        <td class="col3">{{ client.address }}</td>
                        <td class="col4">{{ client.discount }} %</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div id="orderContent">
        <div id="Buttons">
            <h1>Все заказы</h1>
            <button id="addButton" @click="orderShowModal">Добавить</button>
            <button type="button" id="delItemButton">Удалить</button>
            <button type="button" id="editItemButton">Изменить</button>
        </div>
    </div>

    <clientContent v-model:show="clientModalVisible"></clientContent>
    <itemContent v-model:show="itemModalVisible"></itemContent>
    <orderContent v-model:show="orderModalVisible"></orderContent>
</template>

<style>
    * {
        font-family: 'Open Sans', sans-serif;
    }

    #itemContent {
        display: none;       
        position: absolute;
        top: 50px;
    }

    #clientContent {
        display: none;
        position: relative;
        top: 50px;
    }

    #orderContent {
        display: none;
        position: absolute;
        top: 50px;
    }

    #Buttons {
        width: 350px;
        position: absolute;
        top: 100px;
        left: 100px;
    }

    #Buttons button {
        margin-top: 30px;
    }

        #Buttons button:hover {
            background-color: rgb(83, 189, 166);
            transition: 0.5s;
        }

    #delItemButton {
        margin-left: 20px;
    }

    #editItemButton {
        margin-left: 20px;
    }

    #Buttons button {
        height: 30px;
        background-color: rgb(38, 123, 120);
        border: none;
        outline: none;
        color: white;
        font-weight: bold;
        width: 100px;
        border-radius: 5px;
    }

    #divTabel {
        position: absolute;
        left: 100px;
        top: 250px;
        width: calc(100% - 250px);
        transition: all 0.5s;
    }

    table {
        position: relative;
        width: 100%;
        border: 1px solid rgb(38, 123, 120);
        border-radius: 5px;
        border-collapse: separate;
        border-spacing: 0px;
        margin-bottom: 20px;
    }

        table thead th {
            font-weight: bold;
            text-align: left;
            border: none;
            padding: 10px 15px;
            color: white;
            background: rgb(38, 123, 120);
            font-size: 14px;
        }

    table thead tr th:first-child {
        border-radius: 2px 0 0 0;
    }

    table thead tr th:last-child {
        border-radius: 0 2px 0 0;
    }

    table tbody td {
        text-align: left;
        border: none;
        padding: 10px 15px;
        font-size: 14px;
        vertical-align: top;
    }

    table tbody tr:nth-child(even) {
        background: white;
    }

        table tbody tr:last-child td:first-child {
            border-radius: 0 0 0 5px;
        }

        table tbody tr:last-child td:last-child {
            border-radius: 0 0 5px 0;
        }

    .col1 {
        width: 15%;
    }

    .col2 {
        width: 10%;
    }

    .col3 {
        width: 40%;
    }

    .col4 {
        width: 6%;
    }

    .col5 {
        width: 5%;
    }

    #search {
        width: 700px;
        position: absolute;
        top: 167px;
        right: 145px;
        transition: all 0.5s;
    }


     #search input {
        position: absolute;
        right: 85px;
        outline: none;
        border: 1px solid rgb(38, 123, 120); 
        height: 30px;
        width: 275px;
        border-radius: 5px;
        padding-left: 10px;
     }

        #search input:hover {
            border-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

        #search input:focus {
            border-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

    #search button {
        position: absolute;
        outline: none;
        border: none;
        height: 30px;
        width: 70px;
        font-weight: bold;
        border-radius: 5px;
        background-color: rgb(38, 123, 120);
        color: white;
        right: 5px;
    }

        #search button:hover {
            background-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

    form label {
        top: 46px;
        right: 323px;
        position: absolute;
    }

    #filterBy {
        text-align: center;
        position: absolute;
        top: 41px;
        right: 250px;
        height: 30px;
        outline: none;
        border: 1px solid rgb(38, 123, 120);
        border-radius: 5px;
    }

        #filterBy:hover {
            border-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

        #filterBy:focus {
            border-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

    .label {
        top: 46px;
        right: 114px;
        position: absolute;
    }

    #sortBy {
        position: absolute;
        text-align: center;
        right: 5px;
        top: 41px;
        height: 30px;
        outline: none;
        border: 1px solid rgb(38, 123, 120);
        border-radius: 5px;
    }

        #sortBy:hover {
            border-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

        #sortBy:focus {
            border-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

    #showBy {
        text-align: center;
        position: absolute;
        top: 41px;
        right: 416px;
        height: 30px;
        outline: none;
        border: 1px solid rgb(38, 123, 120);
        border-radius: 5px;
    }

        #showBy:hover {
            border-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

        #showBy:focus {
            border-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

    .label2 {
        right: 467px;
        position: absolute;
    }

    select-container {
        position: relative;
        overflow: hidden;
    }
</style>

<script>
    import clientContent from './modalWindows/clientContent.vue'
    import itemContent from './modalWindows/itemContent.vue'
    import orderContent from './modalWindows/orderContent.vue'
    import axios from 'axios'
    export default {
        data() {
            return {
                clientModalVisible: false,
                itemModalVisible: false,
                orderModalVisible: false,
                clientsSort: [axios.get("/AdminPage/GetByFilter", { params: { searchInput: null, filter: "code" } }).then(responses => (this.clientsSort = responses.data))]
            }
        },
        name: 'Content',
        components: {
            clientContent,
            itemContent,
            orderContent
        },
        methods: {
            clientShowModal() {
                this.clientModalVisible = true;
            },

            itemShowModal() {
                this.itemModalVisible = true;
            },

            orderShowModal() {
                this.orderModalVisible = true;
            },

            GetClientsByFilter() {
                axios.get("/AdminPage/GetByFilter", {
                    params:
                    {
                        searchInput: $('#searchString').val(),
                        filter: $('#filterBy').val(),
                        searchDiscountInput: $('#searchString').val(),
                        sort: $('#sortBy').val(),
                        pageSize: $('#showBy').val()
                    }
                }).then(responses => (this.clientsSort = responses.data));
            },
        }
    }
</script>