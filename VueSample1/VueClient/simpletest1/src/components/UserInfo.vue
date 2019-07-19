<template>

  <div>

       <input type="button"  @click="handleClick" value="获取服务端时间" />

       <p>call from server:{{msg}}</p>

  </div>

</template>

<script>

  import axios from 'axios';

  export default{

    data(){

      return {

          msg:""

      }

    },

    methods: {

       handleClick(evt) {

        let _self=this;

        axios.get('https://localhost:44392/api/login/login/user1/pwd1')

             .then(function (response) {

                 //debugger;

                 console.log(response);

                 _self.msg=response.data;

             })

            .catch(function (error) {

              console.log(error);

            });

       }

    }

  }

 

</script>