<template>
  <div class="hello">
    <div v-for="book in booksList" :key="book.id">
      <div class="book-wrapper" @click="bookDetails(book.id)">
        <div class="book-title">Title: {{ book.title }}</div>
        <div class="book-author">Author: {{ book.author }}</div>
        <div class="book-created">Created: {{ book.createdAt | humanize }}</div>
        <div class="book-updated">Updated: {{ book.updatedAt | humanize }}</div>
        <div @click="deleteBook(book.id)" class="delete">X</div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import IBook from "@/types/Book";
import { Component, Prop, Vue } from "vue-property-decorator";
import BookService from "@/services/book-service";

const bookService: BookService = new BookService();

@Component
export default class BooksList extends Vue {
  @Prop({ required: true })
  private booksList!: IBook[];

  private deleteBook(id: number) {
    bookService
      .deleteBook(id)
      .then(() => {
        const book = bookService.getBook(id).then((res) => {
          return res;
        });
        this.$emit("deleted", book);
        alert("Book deleted successfully ");
      })
      .catch((err) => {
        console.log(`Error id ${err}`);
        alert("Problem deleting the book");
      });
  }

  //   private bookDetails(id: number) {}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.book-wrapper {
  position: relative;
  margin: 0.8rem;
  padding: 0.4rem;
  background-color: #cfcdcd;
  border-radius: 1rem;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);

  .book-title {
    font-size: 1.2rem;
    font-weight: bold;
  }

  .book-author {
    color: #333;
  }

  .book-created {
    font-size: 0.9rem;
    color: #333;
  }

  .book-updated {
    font-size: 0.9rem;
    color: #333;
  }

  .delete {
    position: absolute;
    top: 10px;
    right: 10px;
    font-size: 0.8rem;
    font-weight: bold;
    color: #ce3355;
    cursor: pointer;
  }
}
</style>
