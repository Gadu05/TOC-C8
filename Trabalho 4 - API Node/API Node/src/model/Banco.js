import { Client } from "pg";

class Banco {
  static conexao;
  static init() {
    try {
      this.conexao = new Client({
        host: process.env.DB_HOST,
        port: process.env.DB_PORT,
        database: process.env.DB_DATABASE,
        user: process.env.DB_USER,
        password: process.env.DB_PASSWORD,
      });
      this.conexao.connect();
    }
    catch (erro) {
      console.log("Erro de conexao: " + erro);
    }
  }
}

export default Banco;