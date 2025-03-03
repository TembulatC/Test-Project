<template>
    <sidebar/>
</template>

<script>
    import Sidebar from "./components/Sidebar.vue"
    export default {
        components: {
            Sidebar,
        },

        name: 'App'
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
        overflow-y: scroll;
        overflow-x: hidden;
        height: 100%;
    }

    input[type="search"]::-webkit-search-decoration,
    input[type="search"]::-webkit-search-cancel-button,
    input[type="search"]::-webkit-search-results-button,
    input[type="search"]::-webkit-search-results-decoration {
        -webkit-appearance: none;
    }
</style>