import { Client } from "pg";

class Banco {
  static conexao;
  static init() {
    try {
      this.conexao = new Client({
        host: process.env.HOST,
        port: process.env.PORT,
        database: process.env.DATABASE,
        user: process.env.USER,
        password: process.env.PASSWORD,
      });
      this.conexao.connect();
    }
    catch (erro) {
      console.log("Erro de conexao: " + erro);
    }
  }
}

export default Banco;