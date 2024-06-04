<template>
  <v-card
    class="mx-auto"
    max-width="600"
  >
    <v-toolbar color="secondary">
      <v-btn icon="mdi-menu" variant="text"></v-btn>

      <v-toolbar-title>Waiting List</v-toolbar-title>

      <v-spacer></v-spacer>

      <v-btn icon="mdi-magnify" variant="text"></v-btn>

      <v-btn icon="mdi-view-module" variant="text"></v-btn>
    </v-toolbar>
    
    <v-list lines="two">

      <v-list-subheader inset>Wanting to start in next 30 days</v-list-subheader>

<v-row justify="center">
</v-row>

      <v-list-item
        v-for="file in upcomingWaitingList"
        :key="file.title"
        :subtitle="file.startDate"
        :title="file.firstName + ' ' + file.secondName"
      >
        <template v-slot:prepend>
          <v-avatar :color="file.color">
            <v-icon color="white">{{ file.icon }}</v-icon>
          </v-avatar>
        </template>

        <template v-slot:append>
      
          <v-btn
            href="sms:07564282030?body=Hi Sam,%0a%0aHilton driving school here. We added you to our waiting list a while ago and were wondering if you are still interested in driving lessons.%0a%0aCheers Mark"
            color="grey-lighten-1"
            icon="mdi-message"
            variant="text"
          ></v-btn>
          <v-btn
            color="grey-lighten-1"
            icon="mdi-check"
            variant="text"
          ></v-btn>
          <v-btn
            color="grey-lighten-1"
            icon="mdi-close"
            variant="text"
          ></v-btn>
        </template>
      </v-list-item>

      <v-list-subheader inset>Waiting</v-list-subheader>

      <v-list-item
        v-for="file in waitingList"
        :key="file.title"
        :subtitle="file.startDate"
        :title="file.firstName + ' ' + file.secondName"
      >
        <template v-slot:prepend>
          <v-avatar color="green">
            <v-icon color="white">{{ 'mdi-account' }}</v-icon>
          </v-avatar>
          
        </template>

        <template v-slot:append>
          <v-btn
            color="grey-lighten-1"
            icon="mdi-message"
            variant="text"
          ></v-btn>
          <v-btn
            color="grey-lighten-1"
            icon="mdi-check"
            variant="text"
          ></v-btn>
          <v-btn
            color="grey-lighten-1"
            icon="mdi-close"
            variant="text"
          ></v-btn>
        </template>
      </v-list-item>

      <v-divider inset></v-divider>  
      
    </v-list>
  </v-card>

</template>

<script>
import axios from 'axios';
export default {
  data: () => ({
      upcomingWaitingList: [
      {
        color: 'amber',
        icon: 'mdi-account-alert',
        startDate: 'Jan 1, 2024',
        firstName: 'Sam',
        secondName: 'Walker',
      },
      {
        color: 'amber',
        icon: 'mdi-account-alert',
        startDate: 'Jan 2, 2024',
        firstName: 'Joe',
        secondName: 'Walker',
      },
    ],
    waitingList: [
      {
        startDate: 'Jan 9, 2024',
        firstName: 'Nathan',
        secondName: 'Jones',
      },
      {
        startDate: 'Jan 17, 2024',
        firstName: 'Liesl',
        secondName: 'Buchan',
      },
      {
        startDate: 'Jan 28, 2024',
        firstName: 'Adam',
        secondName: 'Sutton',
      },
    ],
  }),

  mounted() {
    const apiUrl = "http://localhost:7180/api/GetProspects";

    axios.get(apiUrl)
      .then(response => {
        this.waitingList = response.data;
      })
      .catch(error => {
        console.error(error);
      });
  }
}
</script>