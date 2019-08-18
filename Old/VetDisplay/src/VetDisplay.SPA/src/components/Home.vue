<template>
<div>
    <!-- <b-jumbotron>
        <template slot="header">{{filterName}}</template>
        <hr class="my-4">
        <VideoList></VideoList>
    </b-jumbotron>  -->
    <div>
        <b-jumbotron>
            <template slot="header">Videos Explicatives</template>
        <hr class="my-4">
        <p v-if="tabIndex==0">Toutes les vidéos sont affichés</p>
        <p v-if="tabIndex==1">Ne sont affichés actuellement que les video de chats</p>
        <p v-if="tabIndex==2">Ne sont affichés actuellement que les video de chiens</p>
        
        <b-card card >
            <b-tabs v-model="tabIndex" fill   vertical>
                <b-tab title="Tous" @click="tabIndex=0"><b-card-text>Beaucoup de texte</b-card-text></b-tab>
                <b-tab title="Chat" @click="tabIndex=1">Beaucoup de texte sur les chats</b-tab>
                <b-tab title="Chien" @click="tabIndex=2"><b-card-text>Beaucoups de texte sur les chiens</b-card-text></b-tab>
            </b-tabs>
        </b-card>
        </b-jumbotron>
    </div>
       
           
    
    </div>
</template>

<script>
import VideoList from "../components/VideoList";
export default {
    components:{
        VideoList,
    },
    data(){
       
        return {
            filterName: '',
            tabIndex: 0,

        }
    }

}
</script>

<style lang="scss">

</style>