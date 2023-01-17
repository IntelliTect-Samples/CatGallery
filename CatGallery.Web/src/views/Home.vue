<template>
  <div class="ma-4">
    <div
      style="
        display: grid;
        grid-template-columns: repeat(auto-fill, minmax(275px, 1fr));
        grid-gap: 16px;
      "
    >
      <v-card v-for="image in photoList.$items" :key="image.$stableId">
        <v-img height="250" :src="image.download.url ?? undefined"></v-img>
        <v-card-text>
          <v-chip
            v-for="tag in image.tags"
            :key="tag.$stableId"
            :color="tag.color || 'primary'"
            dark
            small
            class="mr-1"
          >
            {{ tag.name }}
          </v-chip>
        </v-card-text>
      </v-card>
    </div>
  </div>
</template>

<script setup lang="ts">
import { PhotoListViewModel } from "@/viewmodels.g";
import { watch } from "vue";

const props = defineProps({ galleryVersion: Number });

const photoList = new PhotoListViewModel();
photoList.$pageSize = 1000;
photoList.$load();

watch(
  () => props.galleryVersion,
  () => photoList.$load()
);
</script>
