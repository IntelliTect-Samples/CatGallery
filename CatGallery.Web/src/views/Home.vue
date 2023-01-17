<template>
  <div class="ma-4">
    <div
      style="
        display: grid;
        grid-template-columns: repeat(auto-fill, minmax(275px, 1fr));
        grid-gap: 16px;
      "
    >
      <v-card v-for="(image, n) in images" :key="n">
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
    </div>
  </div>
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
