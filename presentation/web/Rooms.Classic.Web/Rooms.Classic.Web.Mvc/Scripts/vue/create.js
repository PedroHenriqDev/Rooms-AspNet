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
                    if (error.status === 400) {
                        haveErrors = true;
                        errors = error.data.value;
                    }
                    else {
                        console.log(error);
                    }
                });
        }
    }
});