import { Component } from "@angular/core"


@Component({

  selector: "app-produto",
  template: ""

})


export class ProdutoComponent {
  public id: number;
  public nome: string;
  public preco: number;

  public obterNome(): string {
    return this.nome;
  }
}

