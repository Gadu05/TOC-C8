import express from "express";
import cors from "cors";
import dotenv from "dotenv";

const app = express();
dotenv.config();

app.use(express.urlencoded({ extended: true }));
app.use(express.json());
app.use(cors());

import rotasProduto from "./routes/produto.routes.js";

app.use("/", rotasProduto);

app.listen(process.env.SERVER_PORT, process.env.SERVER_HOST, function(erro) {
    if (erro) {
        console.log("Erro ao iniciar o servidor: " + erro);
    }
    else {
        console.log("Servidor iniciado na porta " + process.env.SERVER_PORT);
    }
});