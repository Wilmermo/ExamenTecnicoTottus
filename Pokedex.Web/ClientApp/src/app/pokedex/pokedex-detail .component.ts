import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Pokedex } from '../models/pokedex';
import { ApiprodexService } from '../services/apiprodex.service';

@Component({
  selector: 'app-pokedex-detail',
  templateUrl: './pokedex-detail.component.html',
})
export class PokedexDetailComponent implements OnInit {
  selectedPokedex: Pokedex = new Pokedex();

  constructor(
    private apiPokedex: ApiprodexService,
    private _route: ActivatedRoute,
    private _router: Router
  ) {

  }

  obtenerPokedexIndividual(idPokedex) {
    this.apiPokedex.obtenerPokedexById(idPokedex).subscribe(respuesta => {
      console.log(respuesta);
      this.selectedPokedex.nombre = respuesta.nombre;
      this.selectedPokedex.numero = respuesta.numero;
      this.selectedPokedex.descripcion = respuesta.descripcion;
      this.selectedPokedex.foto = respuesta.foto;
    })
  }

  Regresar(): void {
    this._router.navigate(['/pokedex']);
  }



  ngOnInit() {
    let idPokedex = +this._route.snapshot.paramMap.get('id');
    this.obtenerPokedexIndividual(idPokedex);
  }



}
