<template>
    <div id="itemContent">
        <div id="Buttons">
            <h1>Все товары</h1>
            <button id="addButton" @click="itemShowModal">Добавить</button>
            <button type="button" id="delItemButton2">Удалить</button>
            <button type="button" id="editItemButton2">Изменить</button>
        </div>
    </div>
    <div id="clientContent">
        <div id="Buttons">
            <h1>Все клиенты</h1>
            <button type="button" id="addButton" @click="clientShowModal">Добавить</button>
            <button class="beforeCheck" id="beforeCheck">Удалить</button>
            <button type="button" id="delItemButton" @click="deleteClientShowModal">Удалить</button>
            <button class="beforeCheck edit" id="beforeCheck2">Изменить</button>
            <button type="button" id="editItemButton" @click="updateClientShowModal">Изменить</button>
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

                <input id="searchString" type="search" @keydown.enter="GetClientsByFilter" placeholder="Поиск по имени, коду, адресу или скидке" />
                <button id="searchBtn" type="button" @click="GetClientsByFilter">Найти</button>
            </form>
        </div>

        <div id="divTabel">
            <table class="table">
                <thead>
                    <tr>
                        <th class="col5"></th>
                        <th class="col1">Имя</th>
                        <th class="col2">Код</th>
                        <th class="col6">Почта</th>
                        <th class="col7">Телефон</th>
                        <th class="col3">Адрес пункта выдачи</th>
                        <th class="col4">Скидка</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="client in clientsSort">
                        <td class="col5"><input type="checkbox" id="check" class="check" @click="CheckShow" /></td>
                        <td class="col1">{{ client.name }}</td>
                        <td data-th_name="code" class="col2">{{ client.code }}</td>
                        <td class="col6">{{ client.email }}</td>
                        <td class="col7">{{ client.phoneNumber }}</td>
                        <td class="col3">{{ client.address }}</td>
                        <td class="col4">{{ client.discount }} %</td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="pages">
            <form method="get" class="pagesForm" @submit.prevent>
                <button class="backward" type="button" @click="PageNavigation">&lt;</button>
                <input type="text" id="searchPageString" @keydown.enter="GetClientsByFilter" value="1" />
                <span>из {{ clientsCount }}</span>
                <button class="forward" type="button" @click="PageNavigation">&gt;</button>
            </form>
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
    <deleteClientContent v-model:show="deleteClientModalVisible" v-model:check="codeCheckbox"></deleteClientContent>
    <updateClientContent v-model:show="updateClientModalVisible" v-model:check="codeCheckboxForUpdate"></updateClientContent>
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
    }

    #orderContent {
        display: none;
        position: absolute;
        top: 50px;
    }

    #Buttons {
        display: inline-block;
        width: 340px;
        position: relative;
        margin: 100px 0 0 150px;
    }

    #Buttons button {
        margin-top: 30px;
    }

        #Buttons button:hover {
            background-color: rgb(83, 189, 166);
            transition: 0.5s;
        }

    #delItemButton, #delItemButton2 {
        display: none;
        margin-left: 20px;
    }

    #editItemButton, #editItemButton2 {
        display: none;
        margin-left: 20px;
    }

    #beforeCheck {
        display: inline;
    }

    .beforeCheck {      
        margin-top: 30px;
        margin-left: 20px;
        opacity: 0.5;
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
        position: relative;
        width: calc(100% - 250px);
        transition: all 0.5s;
        margin: 30px 100px 0 150px;
    }

    table {
        position: relative;
        width: 100%;
        border: 1px solid rgb(38, 123, 120);
        border-radius: 5px;
        border-collapse: separate;
        border-spacing: 0px;
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
        width: 20%;
    }

    .col4 {
        width: 6%;
    }

    .col5 {
        width: 2%;
    }

    .col6 {
        width: 13%;
    }

    .col7 {
        width: 10%;
    }

    #search {
        width: 589px;
        position: relative;
        transition: all 0.5s;
        float: right;
        display: inline-block;
        margin: 92px 100px 75px 65px;
        right: 0px;
    }


        #search input {
            position: relative;
            left: 235px;
            outline: none;
            border: 1px solid rgb(38, 123, 120);
            height: 30px;
            width: 275px;
            border-radius: 5px;
            padding-left: 10px;
            transition: all 0.5s;
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
            position: relative;
            outline: none;
            border: none;
            height: 30px;
            width: 70px;
            font-weight: bold;
            border-radius: 5px;
            background-color: rgb(38, 123, 120);
            color: white;
            float: right;
        }

        #search button:hover {
            background-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

    form label {
        top: 75px;
        right: 35px;
        position: relative;
    }

    #filterBy {
        text-align: center;
        position: relative;
        top: 75px;
        right: 30px;
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
        top: 75px;
        right: 5px;
        position: relative;
    }

    #sortBy {
        position: relative;
        text-align: center;
        top: 75px;
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
        position: relative;
        top: 75px;
        right: 60px;
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
        right: 65px;
        position: relative;
        top: 75px;
    }

    select-container {
        position: relative;
        overflow: hidden;
    }

    .pages {
        position: relative;
        width: 233px;
        margin: 40px 0 40px 150px;
    }

    .pagesForm button {
        border: none;
        outline: none;
        height: 30px;
        width: 30px;
        color: white;
        font-weight: bold;
        border-radius: 5px;
        background-color: rgb(38, 123, 120);
    }

        .pagesForm button:hover {
            background-color: rgb(83, 189, 166);
            transition: all 0.5s;
        }

    .pagesForm input {
        height: 30px;
        width: 50px;
        outline: none;
        border: 1px solid rgb(38, 123, 120);
        border-radius: 5px;
        margin: 0 10px 0 10px;
        text-align: center;
        transition: all 0.5s;
    }

        .pagesForm input:hover {
            border-color: rgb(83, 189, 166);
        }

        .pagesForm input:focus {
            border-color: rgb(83, 189, 166);
        }

    .pagesForm span {
        margin-right: 10px;
    }

    #check[type="checkbox"] {
        accent-color: rgb(38, 123, 120);
        
    }
</style>

<script>
    import updateClientContent from './modalWindows/updateClientContent.vue'
    import deleteClientContent from './modalWindows/deleteClientContent.vue'
    import clientContent from './modalWindows/clientContent.vue'
    import itemContent from './modalWindows/itemContent.vue'
    import orderContent from './modalWindows/orderContent.vue'
    import axios from 'axios'
    export default {
        // Начальыне входные данные
        data() {
            return {
                codeCheckbox: [],
                codeCheckboxForUpdate: "",
                updateClientModalVisible: false,
                deleteClientModalVisible: false,
                clientModalVisible: false,
                itemModalVisible: false,
                orderModalVisible: false,
                // Переменная для хранения отфильтрованных пользователей
                clientsSort: [axios.get("/AdminPage/GetByFilter", { params: { searchInput: null, filter: "name", sort: "asc"} }).then(responses => (this.clientsSort = responses.data))],
                // Переменная для ъранения количества страниц
                clientsCount: 0, 
                clientsCountForFilters: [axios.get("/AdminPage/GetAll")
                    // Получение количества всех пользователей
                    .then(responses => (this.clientsCountForFilters = responses.data.length))
                    // Получение количества пользователей с учетом фильтра "Показывать на странице"
                    .then(responses => (this.clientsCount = Math.ceil(responses / $('#showBy').val())))],
            }
        },
        name: 'Content',
        components: {
            updateClientContent,
            deleteClientContent,
            clientContent,
            itemContent,
            orderContent
        },
        methods: {
            // Методы для отображения модальных окон
            clientShowModal() {
                this.clientModalVisible = true;
            },

            itemShowModal() {
                this.itemModalVisible = true;
            },

            orderShowModal() {
                this.orderModalVisible = true;
            },

            deleteClientShowModal() {
                this.deleteClientModalVisible = true;
            },

            updateClientShowModal() {
                this.updateClientModalVisible = true;
            },

            // Метод для фильтрации пользователей
            GetClientsByFilter() {
                // Axios - запрос для получения пользователей по фильтрам
                axios.get("/AdminPage/GetByFilter", {
                    params:
                    {
                        searchInput: $('#searchString').val(),
                        filter: $('#filterBy').val(),
                        searchDiscountInput: $('#searchString').val(),
                        sort: $('#sortBy').val(),
                        page: $('#searchPageString').val(),
                        pageSize: $('#showBy').val()
                    }
                }).then(responses => (this.clientsSort = responses.data));

                // Axios - запрос для получения количества пользователей по фильтрам для пагинации
                axios.get("/AdminPage/GetByFilter", {
                    params:
                    {
                        searchInput: $('#searchString').val(),
                        filter: $('#filterBy').val(),
                        searchDiscountInput: $('#searchString').val(),
                        sort: $('#sortBy').val(),
                        pageSize: this.clientsCountForFilters
                    }
                }).then(responses => (this.clientsCount = Math.ceil(responses.data.length / $('#showBy').val())));
            },

            // Метод для навигации по пользователям
            PageNavigation(btn) {
                if (btn.target.classList.contains("forward") && btn.target.parentElement.querySelector("input").value <= (this.clientsCount - 1)) {
                    // При нажатии кнопки ">" идет переход на следующую страницу таблицы
                    ++btn.target.parentElement.querySelector("input").value;
                    // Вызывается метод для сохранении всех фильтров при переходе на новую страницу
                    this.GetClientsByFilter();
                }

                else if (btn.target.classList.contains("backward") && btn.target.parentElement.querySelector("input").value >= 2) {
                    // При нажатии кнопки "<" идет переход на следующую страницу таблицы
                    --btn.target.parentElement.querySelector("input").value;
                    // Вызывается метод для сохранении всех фильтров при переходе на новую страницу
                    this.GetClientsByFilter();
                }
            },

            // Метод для получение данных пользователя по чекбоксам для удаления и изменения
            CheckShow() {
                // При нажатии на чекбокс кнопки удаления и изменения выбранного пользователя становятся доступными
                if ($(".check").is(':checked')) {
                    document.getElementById("beforeCheck").style.display = "none";
                    document.getElementById("beforeCheck2").style.display = "none";
                    document.getElementById("delItemButton").style.display = "inline";
                    document.getElementById("editItemButton").style.display = "inline";

                    let ls = []

                    // Данные выбранных пользователей собираются в массив для последующего удаления либо изменения
                    // Удаление и изменение пользователей идет по его коду
                    $('.check:checkbox:checked').each((index, checkbox) => {                       
                        let thName, tdName
                        let td = {}

                        $(checkbox).closest('tr').find('.col2').each(function (b, a) {
                            tdName = $(this).text();
                        }).get()

                        $(checkbox).closest('tr').find('td').each(function (i, v) {
                            thName = $(this).data('th_name');
                            if (thName !== undefined) {
                                td[thName] = tdName;
                            }
                        }).get();

                        if (td) {
                            ls[ls.length] = td 
                        }

                        this.codeCheckboxForUpdate = tdName;
                    });

                    // При выборе более одного пользователя становится доступным только кнопка удалить
                    if (ls.length > 1) {
                        document.getElementById("editItemButton").style.display = "none";
                        document.getElementById("beforeCheck2").style.display = "inline";
                    }

                    this.codeCheckbox = ls; 
                    console.log(this.codeCheckboxForUpdate)
                }

                else {
                    document.getElementById("beforeCheck").style.display = "inline";
                    document.getElementById("beforeCheck2").style.display = "inline";
                    document.getElementById("delItemButton").style.display = "none";
                    document.getElementById("editItemButton").style.display = "none";
                }
            },
        }
    }
</script>