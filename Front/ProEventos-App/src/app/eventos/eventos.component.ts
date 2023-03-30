import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  showImage: boolean = true;
  private _search: string = "";

  public get search(): string {
    return this._search;
  }

  public set search(value: string) {
    this._search = value;
    this.eventosFiltrados = this.search ? this.filterEvents(this.search) : this.eventos;
  }

  constructor(
    private http: HttpClient,
  ) { }

  ngOnInit(): void {
    this.getEventos();
  }

  filterEvents(filterSearch: string): any {
    filterSearch = filterSearch.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filterSearch) !== -1
    )
  }

  setShowImage(): void {
    this.showImage = !this.showImage;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = response;
      },
      error => console.log(error)
    );
  }
}
