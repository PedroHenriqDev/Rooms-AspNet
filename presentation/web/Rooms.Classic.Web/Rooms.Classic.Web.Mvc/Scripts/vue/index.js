var app = new Vue({
    el: '#app',
    data: {
        roomTypes: []
    },
    created() {
        this.fetchRoomTypes();
    },
    methods: {
        fetchRoomTypes() {
            axios.get("https://localhost:7055/RoomTypes")
                .then(response => {
                    console.log(response);
                    this.roomTypes = response.data.value
                    this.formatCreatedAt();
                })
                .catch(error => console.log(error));
        },
        formatCreatedAt() {
            this.roomTypes.forEach(r => {
                console.log
                r.createdAt = this.formatDate(new Date(r.createdAt));
;          });
        },
        formatDate(date) {
            return date.toLocaleDateString('pt-BR', { day: '2-digit', month: '2-digit', year: 'numeric' });
        }
    }
});
