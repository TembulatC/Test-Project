<template>
    <div class="orderModal" v-if="show" @click.stop="hideModal">
        <div class="modalContent" @click.stop>
            чгоооооооо3
        </div>
    </div>
</template>

<script>
    export default {
        name: "orderContent",
        props: {
            show: {
                type: Boolean,
                default: false
            }
        },
        methods: {
            hideModal() {
                this.$emit('update:show', false)
            }
        }
    }
</script>

<style scoped>
    .orderModal {
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
        min-width: 300px;
    }
</style>