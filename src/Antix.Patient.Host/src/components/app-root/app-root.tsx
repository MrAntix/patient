import { Component, h } from '@stencil/core';

@Component({
  tag: 'app-root',
  styleUrl: 'app-root.css',
  shadow: true,
})
export class AppRoot {
  render() {
    return <div>
      <header class="header content">
        <h1 class="title">
          Patient Diary
        </h1>
      </header>

      <main>
        <app-home />
      </main>
    </div>
  }
}
