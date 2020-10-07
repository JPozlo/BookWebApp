import IBook from "@/types/Book";
import axios from "axios";

export default class BookService {
  API_URL = process.env.VUE_APP_API_URL;

  public async getBook(id: number): Promise<IBook> {
    const result = await axios.get(`${this.API_URL}/books/${id}`);
    console.log(`The result is: ${result.data}`);
    return result.data;
  }

  public async getAllBooks(): Promise<IBook[]> {
    const result = await axios.get(`${this.API_URL}/books/`);
    console.log(`The result is: ${result.data}`);
    return result.data;
  }

  public async addBook(book: IBook): Promise<any> {
    const result = await axios.post(`${this.API_URL}/books/`, book);
    console.log(`The added book is: ${result.data}`);
    console.log(`The adding book result is: ${result.status}`);
    return result.data;
  }

  public async deleteBook(id: number): Promise<any> {
    const result = await axios.delete(`${this.API_URL}/books/${id}/`);
    console.log(`The delete book is: ${result.data}`);
    return result.data;
  }
}
