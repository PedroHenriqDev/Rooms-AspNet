Vue.use(Toasted, {
    position: 'bottom-center',
    duration: 3000
});

var app = new Vue({
    el: '#app',
    data: {
        roomTypes: [],
        isLoading: false
    },
    created() {
        this.fetchRoomTypes();
        this.notify();
    },
    methods: {
        fetchRoomTypes() {
            this.isLoading = true;
            axios.get("https://localhost:7055/RoomTypes")
                .then(response => {
                    console.log(response);
                    this.roomTypes = response.data.value;
                    this.formatCreatedAt();
                })
                .catch(error => console.log(error))
                .finally(() =>  this.isLoading = false );
        },
        notify() {
            const key = "success";
            const notification = localStorage.getItem(key);
            if (notification) {
                this.$toasted.success(notification);
                localStorage.removeItem(key);
            }
        },
        formatCreatedAt() {
            this.roomTypes.forEach(r => {
                r.createdAt = this.formatDate(new Date(r.createdAt));
            });
        },
        formatDate(date) {
            return date.toLocaleDateString('pt-BR', { day: '2-digit', month: '2-digit', year: 'numeric' });
        },
        redirectToDelete(roomType) {
            window.location.href = `/roomtypes/delete/${roomType.id}`;
        }
    }
});
