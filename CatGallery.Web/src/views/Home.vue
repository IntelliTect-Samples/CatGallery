<template>
  <v-row class="ma-2">
    <v-col
      v-for="(image, n) in images"
      :key="n"
      class="d-flex child-flex"
      cols="3"
    >
      <v-card>
        <v-img height="250" :src="image.imageUrl"></v-img>
        <v-card-text>
          <v-chip
            v-for="(tag, tagN) in image.tags"
            :key="`${n}-${tagN}`"
            :color="tag.color"
            dark
            small
            class="mr-1"
          >
            {{ tag.name }}
          </v-chip>
        </v-card-text>
      </v-card>
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
const images = [...Array(10)].map((i) => ({
  imageUrl: "https://via.placeholder.com/450",
  tags: [
    { name: "Tag 1", color: "#345678" },
    { name: "Tag 2", color: "#876543" },
  ],
}));
</script>
