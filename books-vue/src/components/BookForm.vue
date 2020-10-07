<template>
  <div class="add-book-form">
    <ul class="new-book">
      <li>
        <label for="title">Book Title</label>
        <input type="text" id="title" v-model="book.title" />
      </li>
      <li>
        <label for="author">Book Author</label>
        <input type="text" id="author" v-model="book.author" />
      </li>
    </ul>
    <button :disabled="isButtonDisabled" @click="addBook">Add Book</button>
  </div>
</template>

<script lang="ts">
import BookService from "@/services/book-service";
import IBook from "@/types/Book";
import { Component, Vue } from "vue-property-decorator";

const bookService = new BookService();

@Component
export default class BookForm extends Vue {
  private book: IBook = {
    author: "",
    title: "",
  };

  get isButtonDisabled() {
    return this.book.title === "" || this.book.author === "";
  }

  private addBook() {
    bookService
      .addBook(this.book)
      .then((res) => {
        alert(`Book by ${res} added successfully`);
      })
      .catch((err) => {
        console.log(`Error id ${err}`);
        alert("Problem deleting the book");
      });
  }
}
</script>

<style scoped lang="scss">
.new-book {
  list-style: none;
  padding: 0;
  margin: 0;
}

input {
  height: 1.8rem;
  margin-bottom: 1.2rem;
  font-size: 1.1rem;
  line-height: 1.3rem;
  padding: 0.2rem;
  color: #555;
}

label {
  font-weight: bold;
  display: block;
  margin-bottom: 0.3rem;
}
</style>
