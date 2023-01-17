<template>
  <v-app id="vue-app">
    <v-app-bar app color="white" dense clipped-left>
      <v-toolbar-title>
        <router-link to="/" style="text-decoration: none">
          <v-icon left color="primary">fa fa-cat</v-icon>
          Cat Gallery
        </router-link>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-dialog max-width="500px" v-model="uploadOpen">
        <template #activator="{ on }">
          <v-btn v-on="on" text>
            <v-icon left>fa fa-upload</v-icon> Upload
          </v-btn>
        </template>

        <v-card>
          <v-card-title>
            Upload Image
            <v-spacer></v-spacer>
            <v-btn @click="uploadOpen = false" title="Close" icon>
              <v-icon> fa fa-times</v-icon>
            </v-btn>
          </v-card-title>
          <v-card-text>
            <!-- File Input -->
            <input type="file" />

            <!-- Visibility Input -->
            <v-radio-group row label="Visibility:">
              <v-radio :value="true" label="Public"></v-radio>
              <v-radio :value="false" label="Private"></v-radio>
            </v-radio-group>

            <!-- File Input -->
            <v-combobox
              v-model="selectedTags"
              label="Tags"
              multiple
              chips
              deletable-chips
              small-chips
            ></v-combobox>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
              color="primary"
              @click="alert('placeholder - perform upload')"
            >
              Upload
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <v-btn text to="/admin"> <v-icon left>fa fa-cogs</v-icon> Admin </v-btn>
    </v-app-bar>

    <v-main>
      <transition name="router-transition" mode="out-in" appear>
        <!-- https://stackoverflow.com/questions/52847979/what-is-router-view-key-route-fullpath -->
        <router-view ref="routeComponent" :key="$route.path" />
      </transition>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { ref, computed, watch, reactive } from "vue";

const alert = window.alert.bind(window);
const uploadOpen = ref(false);
const selectedTags = ref([]);
</script>

<style lang="scss">
.router-transition-enter-active,
.router-transition-leave-active {
  transition: 0.1s ease-out;
}

.router-transition-move {
  transition: transform 0.4s;
}

.router-transition-enter,
.router-transition-leave-to {
  opacity: 0;
}
</style>
