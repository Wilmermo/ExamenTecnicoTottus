import { Component, OnInit } from '@angular/core';
import { Filtro } from '../models/filtro';
import { ApiprodexService } from '../services/apiprodex.service';

@Component({
  selector: 'app-pokedex',
  templateUrl: './pokedex.component.html',
})
export class PokedexComponent implements OnInit {
  public Pokedexs: any;
  public nombre: string;
  public numero: string;

  constructor(private apiPokedex: ApiprodexService) {

  }

  ngOnInit(): void {
    this.getPokedex();
  }

  getPokedex() {
    const filtro: Filtro = { nombre: this.nombre, numero: this.numero};
    this.apiPokedex.obtenerPokedex(filtro).subscribe(respuesta => {
      this.Pokedexs = respuesta;
    });
  }

}
