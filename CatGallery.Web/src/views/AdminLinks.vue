<template>
  <v-card class="mt-5 mx-auto" max-width="500px">
    <v-card-title>
      Admin Page Links
      <v-spacer></v-spacer>
      <a href="/coalesce-security" class="headline font-weight-light">
        Security Overview
      </a>
    </v-card-title>
    <v-card-text class="black--text">
      <v-simple-table dense>
        <thead>
          <tr>
            <th>Type</th>
            <th>Admin Table</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="typeMeta in adminTypes" :key="typeMeta.name">
            <td>
              {{ typeMeta.displayName }}
            </td>
            <td>
              <router-link
                :to="{
                  name: 'coalesce-admin-list',
                  params: { type: typeMeta.name },
                }"
              >
                Table
              </router-link>
            </td>
          </tr>
        </tbody>
      </v-simple-table>
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import $metadata from "@/metadata.g";

const adminTypes = Object.values($metadata.types).filter(
  (t) => t.type == "model"
);
</script>
