<template>
  <div>
    <div>
      <b-jumbotron>
    <template slot="header">Ajoutez une video</template>
     <hr class="my-4">
    <form enctype="multipart/from-data">
      <input  style="display: none" type="file" ref='file' @change="handleUpload($event.target.files)" hidden >
      
      <b-container>
        <b-row>
          <b-col>
      <b-button @click="$refs.file.click()" variant="primary">Choisissez un media</b-button>

          </b-col>
          <b-col></b-col>
          <b-col>
           <div  v-if="fileName != null">
            <b-button variant="primary" @click="submitMedia" >Submit</b-button>
          </div>
          </b-col>
        </b-row>
      </b-container>
     
      <div v-if="fileName != null">
        <h3>titre: {{fileName}} </h3>
       </div>
      
     <div v-if="uploadPercentage != 0 ">
      <hr class="my-4">
      <b-progress :value="uploadPercentage" :max="100" class="mb-3"></b-progress>

    </div>
    <div v-if="uploadPercentage == 100">
 <b-alert show variant="success">Importation de {{fileName}} réussite</b-alert>
<hr class="my-4">
    </div>
    <div v-if="imagePreview != ''">
        <b-img v-bind:src="imagePreview" v-show="showPreview" fluid ></b-img>
    </div>
    </form>
  </b-jumbotron>
</div>

     

  </div>
</template>

<script>
import axios from 'axios';
import AuthService from "../services/AuthService";

export default {
  data(){
    return {
      selectedFile: null,
      file: new FormData(),
      file1:'', 
      uploadPercentage: 0,
      showPreview: false,
      imagePreview: '',
      fileName: null,
  }
  },

  methods: {

    async refresh(){
     
    },

    async submitMedia(){
      event.preventDefault();
     
     let data = await axios.post(
       'http://localhost:5000/api/Media/uploadMedia', this.file,
       {
         headers: {
           "Content-type" : "multipart/form-data",
           Authorization: `Bearer ${AuthService.accesToken}` 
         },
         responseType: "application/json",
        onUploadProgress:function(progressEvent){
         
         this.uploadPercentage = parseInt( Math.round( ( progressEvent.loaded * 100 ) / progressEvent.total )); 
        }.bind(this)
      }).then( function(){
        console.log("SUCCESS");
      }).catch(function(){
        console.log("FAIRURE");
      });

    },

    async handleUpload(files) {
       this.file.append("media", files[0], files[0].name);

      if(/\.(jpe?g|png|gif)$/i.test( files[0].name ) ) {
        this.file1 = this.$refs.file.files[0];
        let reader = new FileReader();
        reader.addEventListener("load", function() {
          this.showPreview = true;
          this.imagePreview = reader.result;
        }.bind(this), false);

       reader.readAsDataURL(this.file1);
       await this.refresh();
      }
      this.fileName = files[0].name;
    }
  }
}
</script>
