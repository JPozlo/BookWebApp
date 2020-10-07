<template>
  <div class="books">
    <h1>My Books</h1>
    <div v-if="myBooks.length">
      <BooksList @deleted="getAllBooks" :booksList="myBooks" />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import BooksList from "@/components/BooksList.vue"; // @ is an alias to /src
import BookService from "@/services/book-service";
import IBook from "@/types/Book";

const bookService = new BookService();

@Component({
  name: "Books",
  components: {
    BooksList,
  },
})
export default class Books extends Vue {
  // data
  myBooks: IBook[] = [];

  // computed properties
  get bookCount() {
    return this.myBooks.length;
  }

  // props

  // methods

  getAllBooks() {
    bookService.getAllBooks().then((res) => (this.myBooks = res));
  }

  // lifecycle hooks
  created() {
    this.getAllBooks();
  }

  // watchers
}
</script>
