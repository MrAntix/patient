importScripts("workbox-v6.5.4/workbox-sw.js");

self.__WB_DISABLE_DEV_LOGS = true;

self.addEventListener("message", ({ data }) => {

  if (data === "skip") self.skipWaiting();
});

self.addEventListener("activate", event => {

  event.waitUntil(clients.claim());
});

self.addEventListener('install', (event) => {
  const controller = new workbox.precaching.PrecacheController();

  controller.addToCacheList(self.__WB_MANIFEST);
  event.waitUntil(controller.activate(event));
});

self.workbox.routing.setDefaultHandler(
  new workbox.strategies.StaleWhileRevalidate()
);

self.workbox.routing.setCatchHandler(async request => {

  console.log('catch', request);

  return self.workbox.precaching.matchPrecache(request);
});

self.workbox.routing.registerRoute(
  new RegExp('/api/.*'),
  new workbox.strategies.NetworkOnly({
    cacheName: 'api'
  })
);
