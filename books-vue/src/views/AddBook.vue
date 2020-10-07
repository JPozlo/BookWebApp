<template>
  <div class="add-book-wrapper">
    <h1>Add Book</h1>
    <div>
      <BookForm />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import BookForm from "@/components/BookForm.vue"; // @ is an alias to /src

@Component({
  name: "AddBook",
  components: {
    BookForm,
  },
})
export default class AddBook extends Vue {}
</script>
