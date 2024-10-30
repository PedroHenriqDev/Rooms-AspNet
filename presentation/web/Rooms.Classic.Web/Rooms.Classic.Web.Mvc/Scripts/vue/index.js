Vue.use(Toasted, {
    position: 'bottom-center',
    duration: 3000
});

var app = new Vue({
    el: '#app',
    data: {
        roomTypes: [],
        urlBase: 'https://localhost:7055/RoomTypes/',
        isLoading: false,
        totalItems: 0,
        nameFilter: '',
        minFilter: '',
        maxFilter: '',
        modal: ''
    },
    created() {
        this.fetchRoomTypes();
        this.notify();
    },
    methods: {
        fetchRoomTypes() {
            this.isLoading = true;
            axios.get(this.urlBase)
                .then(response => {
                    console.log(response);
                    this.roomTypes = response.data.value;
                    const pagination = JSON.parse(response.headers['x-pagination']);
                    this.totalItems = pagination.TotalItems;
                    this.formatCreatedAt();
                })
                .catch(error => console.log(error))
                .finally(() =>  this.isLoading = false );
        },
        search() {
            this.isLoading = true;
            this.closeModal();
            axios.get(this.mountUrlSearch()).then(response => {
                this.roomTypes = response.data.value;
                this.formatCreatedAt();
            }).catch(error => {
                console.log('Error');
            }).finally(() => {
                this.isLoading = false;
                this.openModal();
            });
        },
        mountUrlSearch() {
            let urlSearch = this.urlBase + 'search?';
            if (this.nameFilter) {
                urlSearch = urlSearch + `name=${this.nameFilter}&`;
            }

            if (this.minFilter) {
                urlSearch = urlSearch + `minDate=${this.minFilter}&`;
            }

            if (this.maxFilter) {
                urlSearch = urlSearch + `maxDate=${this.maxFilter}&`;
            }

            return urlSearch;
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
        formatDateISO(date) {
            return date instanceof Date && !isNaN(date) ? date.toISOString().split('T')[0] : '';
        },
        redirectToDelete(roomType) {
            window.location.href = `/roomtypes/delete/${roomType.id}`;
        },
        redirectToEdit(roomType) {
            window.location.href = `/roomtypes/edit/${roomType.id}`;
        },
        openModal() {
            if (!this.modal) {
                this.modal = new bootstrap.Modal(this.$refs.modalSearch);
            }
            this.modal.show();
        },
        closeModal() {
            if (this.modal) {
                console.log('Here close modal');
                this.modal.hide();
            }
        }
    }
});
