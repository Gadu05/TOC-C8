
import { Router } from "express";
import ProdutoDAO from "../src/controller/ProdutoDAO.js";

const router = Router();
const dao = new ProdutoDAO();

router.post("/produtos", async (req, res) => {
    
    const { descricao, preco, qtde } = req.body;

    if (!descricao || preco == null || qtde == null) {
        return res.status(400).send(HttpCat(400));
    }

    try {
        const resultado = await dao.gravar({ descricao, preco, qtde });
        return res.status(201).json({ message: "Produto criado com sucesso", codigo: resultado });
    }
    catch (erro) {
        return res.status(500).send(HttpCat(500));
    }

});

router.get("/produtos", async (req, res) => {

    try {
        const produtos = await dao.listar();
        return res.status(200).json(produtos);
    }
    catch (erro) {
        return res.status(500).send(HttpCat(500));
    }

});

router.put("/produtos", async (req, res) => {

    const { codigo, descricao, preco, qtde } = req.body;

    if (codigo == null || !descricao || preco == null || qtde == null) {
        return res.status(400).send(HttpCat(400));
    }

    try {
        const resultado = await dao.alterar({ codigo, descricao, preco, qtde });
        return res.status(200).json({ message: "Produto alterado com sucesso", linhasAfetadas: resultado });
    }
    catch (erro) {
        return res.status(500).send(HttpCat(500));
    }

});

router.delete("/produtos", async (req, res) => {

    const { codigo } = req.body;

    if (codigo == null) {
        return res.status(400).send(HttpCat(400));
    }

    try {
        const resultado = await dao.excluir(codigo);
        return res.status(200).json({ message: "Produto excluído com sucesso", linhasAfetadas: resultado });
    }
    catch (erro) {
        return res.status(500).send(HttpCat(500));
    }

});

function HttpCat(status) {
    return `
    <html>
        <body style="text-align: center;">
            <img src="https://http.cat/${status}" alt="HTTP Status ${status} style="max-width: 100%; height: auto;"">
        </body>
    </html>`;
}

export default router;