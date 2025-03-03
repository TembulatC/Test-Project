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

        <div class="pagination">
            <span>Показывать на странице:</span>
            <button type="button" class="takeButton" value="25" @click="sortClientsByCodeDesc(25)">25</button>
            <button type="button" class="takeButton" value="50" @click="sortClientsByCodeDesc(50)">50</button>
            <button type="button" class="takeButton" value="100" @click="sortClientsByCodeDesc(100)">100</button>
        </div>

        <div id="search">
            <form method="get" @submit.prevent>
                <label for="filterBy">Поиск по:</label>
                <select id="filterBy">
                    <option value="name">Имени</option>
                    <option value="code">Коду</option>
                    <option value="address">Адресу</option>
                    <option class="byDiscount" value="discount">Скидке</option>
                </select>

                <label for="sortBy" class="label">Сортировка по:</label>
                <select id="sortBy">
                    <option class="byS" value="asc">Возрастанию</option>
                    <option class="byS" value="desc">Убыванию</option>
                </select>

                <input id="searchString" type="search" placeholder="Поиск по имени, коду, адресу или скидке" />
                <button id="searchBtn" type="button" @click="filterClientsByFilter">Найти</button>
            </form>
        </div>

        <div id="divTabel">
            <table>
                <thead>
                    <tr>
                        <th class="col5"><input type="checkbox" name="select" /></th>
                        <th class="col1">Имя <button class="trBtn" type="button" @click="sortClientsByNameDesc">&#9660;</button><button class="trBtn" type="button" @click="sortClientsByNameAsc">&#9650;</button></th>
                        <th class="col2">Код <button class="trBtn" type="button" @click="sortClientsByCodeDesc">&#9660;</button><button class="trBtn" type="button" @click="sortClientsByCodeAsc">&#9650;</button></th>
                        <th class="col3">Адрес пункта выдачи</th>
                        <th class="col4">Скидка <button class="trBtn" type="button" @click="sortClientsByDiscountDesc">&#9660;</button><button class="trBtn" type="button" @click="sortClientsByDiscountAsc">&#9650;</button></th>
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

    .trBtn {
        border: none;
        height: 20px;
        width: 15px;
        font-size: 10px;
        background-color: rgb(38, 123, 120);
        color: white;
        transition: all 0.5s;
        border-radius: 5px;
    }

        .trBtn:hover {
            background-color: rgb(83, 189, 166);
        }

        .trBtn:focus {
            background-color: rgb(83, 189, 166);
        }

    #search {
        width: 400px;
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

    select-container {
        position: relative;
        overflow: hidden; /* Скрываем стандартную стрелку браузера */
    }

    .pagination {
        min-width: 300px;
        position: absolute;
        left: 100px;
        top: 199px;
    }

    .pagination span {
        left: 0px;
        opacity: 1;
        color: black;
        position: relative;
        font-weight: normal;
    }

    .pagination button {
        border: none;
        outline: none;
        height: 30px;
        width: 37px;
        color: white;
        margin-left: 10px;
        border-radius: 5px;
        font-weight: bold;
        background-color: rgb(38, 123, 120);
    }

        .pagination button:hover {
            background-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

        .pagination button:focus {
            background-color: rgb(83, 189, 166);
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
                clientsSort: [axios.get("/AdminPage/GetAllByCode", { params: { sort: false, page: 0, pageSize: 25 } }).then(responses => (this.clientsSort = responses.data))]
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

            sortClientsByNameDesc() {
                axios.get("/AdminPage/GetAllByName", { params: { sort: false } }).then(responses => (this.clientsSort = responses.data));
            },

            sortClientsByNameAsc() {
                axios.get("/AdminPage/GetAllByName", { params: { sort: true } }).then(responses => (this.clientsSort = responses.data));
            },

            sortClientsByCodeDesc(value) {
                    axios.get("/AdminPage/GetAllByCode", { params: { sort: false, page: 0, pageSize: value } }).then(responses => (this.clientsSort = responses.data));               
            },

            sortClientsByCodeAsc() {
                axios.get("/AdminPage/GetAllByCode", { params: { sort: true, page: 0, pageSize: value } }).then(responses => (this.clientsSort = responses.data));
            },

            sortClientsByDiscountDesc() {
                axios.get("/AdminPage/GetAllByDiscount", { params: { sort: false } }).then(responses => (this.clientsSort = responses.data));
            },

            sortClientsByDiscountAsc() {
                axios.get("/AdminPage/GetAllByDiscount", { params: { sort: true } }).then(responses => (this.clientsSort = responses.data));
            },

            filterClientsByFilter() {
                axios.get("/AdminPage/GetByFilter", { params: { searchInput: $('#searchString').val(), filter: $('#filterBy').val(), searchDiscountInput: $('#searchString').val(), sort: $('#sortBy').val() } }).then(responses => (this.clientsSort = responses.data));
            },
        }
    }
</script>