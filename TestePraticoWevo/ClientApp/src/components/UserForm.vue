<template>
    <h1 id="tableLabel">Adicionar/Editar Usuario</h1>

    <p>Dados persistidos no banco MySQL</p>

    <p v-if="!users"><em>Carregando...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel">
        <tbody>
            <tr>
                <th>Nome</th>
                <td><input type="text" name="Name" id="Name" placeholder="Dummy" value=""/></td>
            </tr>
            <tr>
                <th>CPF</th>
                <td><input type="text" name="Cpf" id="Cpf" placeholder="000.000.000-00" value="" /></td>
            </tr>
            <tr>
                <th>Email</th>
                <td><input type="email" name="Email" id="Email" placeholder="dummy@email.com" value="" /></td>
            </tr>
            <tr>
                <th>Telefone</th>
                <td><input type="text" name="Phone" id="Phone" placeholder="+55 21 000.000.000" value="" /></td>
            </tr>
            <tr>
                <th>Sexo</th>
                <td><input type="number" name="Gender" id="Gender" placeholder="0 ou 1" value="" /></td>
            </tr>
            <tr>
                <th>Data de Nascimento</th>
                <td><input type="datetime" name="BirthDate" id="BirthDate" placeholder="00/00/0000" value="" /></td>
            </tr>
        </tbody>
    </table>
    <button v-on:click="postUser" class="btn btn-primary">Salvar</button>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "UserForm",
        data() {
            return {
                users: []
            }
        },
        methods: {
            getUser(id){
                axios.get('/api/user/'+id)
                    .then((response) => {
                        this.user = response.data;
                        document.getElementById("Name").value = this.user.name ,
                        document.getElementById("Cpf").value = this.user.cpf ,
                        document.getElementById("Email").value = this.user.email ,
                        document.getElementById("Phone").value = this.user.phone ,
                        document.getElementById("Gender").value = this.user.gender ,
                        document.getElementById("BirthDate").value = this.user.birthDate
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            postUser() {
                axios.post('/api/user', {
                    name:       document.getElementById("Name").value,
                    cpf:        document.getElementById("Cpf").value,
                    email:      document.getElementById("Email").value,
                    phone:      document.getElementById("Phone").value,
                    gender:     document.getElementById("Gender").value,
                    birthDate:  document.getElementById("BirthDate").value 
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
            this.getUser(1);
        }
    }
</script>