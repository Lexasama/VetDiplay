<template>
<div>

      <div class="row">
         
        <div class="col-sm-3 nopadding">
        <div class="embed-responsive embed-responsive-16by9">
          <video width="540" height="310" controls>
            <source src="../assets/1.mp4" type="video/mp4">
          </video>
        </div>
      </div>
      
      <div class="col-sm-3 nopadding" v-for="link in links" :key="link">
        <div class="embed-responsive embed-responsive-16by9">
          <iframe width="560" height="315" :src="link" allowfullscreen></iframe>
        </div>
      </div>
</div>
     
   

</div>
</template>
<script>


export default {
  data() {
    return {
      videos: [],
      links: ["https://www.youtube.com/embed/esw88_gKOpA","https://www.youtube.com/embed/A-WOTR8qA54",
      "https://www.youtube.com/embed/2fOc8wXP8kQ","https://www.youtube.com/embed/O209XqBZVE0",
      ],
    }
  },
  computed: {
    
  },
  async mounted() {
    

  },

}
</script>

<style scoped>
body {
  background-color: #222;
  color: #ccc;
}
/* remove defaults from responsive cols */

.nopadding {
  padding: 20px !important;
  margin: 0 !important;
  outline: 2px solid #333;
  background: #333;
}
</style>

