<template>
    <h1 id="tableLabel">Usuarios</h1>

    <p>...</p>

    <p v-if="!users"><em>Carregando...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" v-if="users">
        <thead>
            <tr>
                <th>Id</th>
                <th>Nome</th>
                <th>CPF</th>
                <th>Email</th>
                <th>Telefone</th>
                <th>Sexo</th>
                <th>Data de Nascimento</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="user of users" v-bind:key="user.id">
                <td>{{ user.id }}</td>
                <td>{{ user.name }}</td>
                <td>{{ user.cpf }}</td>
                <td>{{ user.email }}</td>
                <td>{{ user.phone }}</td>
                <td>{{ user.gender }}</td>
                <td>{{ user.birthDate }}</td>
            </tr>
        </tbody>
    </table>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "Users",
        data() {
            return {
                users: []
            }
        },
        methods: {
            getUsers() {
                axios.get('/api/user')
                    .then((response) => {
                        this.users = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            postUsers() {
                axios.post('/api/user', {
                    name: 'Bruna Alves',
                    cpf: '12345678910',
                    email: 'bruna.alves@wevo.io',
                    phone: '1142399200',
                    gender: 0,
                    birthDate: '1995-05-29T00:00:00'
                })
                    .then((response) => {
                        this.users = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
        },
        mounted() {
            this.getUsers();
            //this.postUsers();
        }
    }
</script>