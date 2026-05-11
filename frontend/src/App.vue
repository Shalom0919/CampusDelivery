<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { getDbPing } from '@/api/http'

type LoadStatus = 'idle' | 'loading' | 'success' | 'error'

const status = ref<LoadStatus>('idle')
const message = ref('')
const count = ref<number | null>(null)
const errorMessage = ref('')

async function loadDbPing() {
  status.value = 'loading'
  errorMessage.value = ''

  try {
    const result = await getDbPing()
    message.value = result.message
    count.value = result.count
    status.value = 'success'
  } catch (error) {
    status.value = 'error'
    errorMessage.value = error instanceof Error ? error.message : 'Request failed. Please try again.'
  }
}

onMounted(() => {
  void loadDbPing()
})
</script>

<template>
  <main class="container">
    <h1>Campus Delivery</h1>

    <section class="panel">
      <p v-if="status === 'loading'" class="muted">Loading Oracle status...</p>

      <div v-else-if="status === 'success'" class="result">
        <p><strong>Message:</strong> {{ message }}</p>
        <p><strong>Count:</strong> {{ count }}</p>
      </div>

      <div v-else-if="status === 'error'" class="error">
        <p>Failed to load Oracle status.</p>
        <p class="muted">{{ errorMessage }}</p>
        <button type="button" @click="loadDbPing">Retry</button>
      </div>
    </section>
  </main>
</template>

<style scoped>
.container {
  max-width: 720px;
  margin: 48px auto;
  padding: 0 16px;
  font-family: Arial, sans-serif;
}

h1 {
  margin-bottom: 20px;
}

.panel {
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 16px;
}

.result p,
.error p {
  margin: 8px 0;
}

.muted {
  color: #666;
}

button {
  margin-top: 8px;
  border: 1px solid #333;
  border-radius: 6px;
  padding: 6px 12px;
  background: #fff;
  cursor: pointer;
}

button:hover {
  background: #f3f3f3;
}
</style>
