<template>
    <div class="clientModal" v-if="show" @click.stop="hideModal">
        <div class="modalContent" @click.stop>
            <form method="post" @submit.prevent>
                <h1>Удаление клиента клиента</h1>
                <div class="button">
                    <input type="submit" id="addClientButton" value="Удалить"/>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        name: "deleteClientContent",
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
</style>