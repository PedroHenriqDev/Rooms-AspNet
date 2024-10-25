var app = new Vue({
    el: '#app',
    data: {
        name: '',
        errors: [],
        haveErrors: false
    },
    methods: {
        register() {
            axios.post("https://localhost:7055/RoomTypes", {  Name: this.name } )
                .then(response => {
                    localStorage.setItem('success', `Success in create room type with name: ${this.name}`);
                    window.location.href = "/RoomTypes/Index";
                })
                .catch(error => {
                    console.log(error.response.data);
                    if (error.response.status === 400) {
                        this.haveErrors = true;
                        this.errors = this.getUniqueKeysErrors(error.response.data.value);
                    }
                    else {
                        console.log(error);
                    }
                });
        },
        getUniqueKeysErrors(errors) {
            let uniqueErrors = [];

            errors.forEach(err => {
                if (!uniqueErrors[err.key]) {
                    uniqueErrors[err.key] = err.message;
                }
            });

            return Object.values(uniqueErrors);
        }
    }
});