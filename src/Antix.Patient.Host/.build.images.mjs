import imagemin from 'imagemin';
import imageminPngquant from 'imagemin-pngquant';
import convertPkg from 'convert-svg-to-png';
const { convertFile } = convertPkg;

import * as fs from 'fs';
import toIco from 'to-ico';

const appIcon = 'patient';
const outRoot = './src/assets';
const appleBg = '#ffffff';
const iconsBg = undefined; //'#f6f6f6';

(async () => {
  const buildPath = `${outRoot}/build`;

  await fs.promises.mkdir(buildPath + '/icons', { recursive: true });

  await convertToPNG(appIcon, { width: 24 }, true);
  await convertToPNG(appIcon, { width: 48 }, true);
  await convertToPNG(appIcon, { width: 96 }, true);
  await convertToPNG(appIcon, { width: 144 }, true);
  await convertToPNG(appIcon, { width: 192 }, true);
  await convertToPNG(appIcon, { width: 256 }, true);
  await convertToPNG(appIcon, { width: 384 }, true);
  await convertToPNG(appIcon, { width: 512 }, true);
  await convertToPNG(appIcon, { width: 1024 });
  await convertToPNG(appIcon, { width: 1080, height: 1920 });
  await convertToICO(appIcon, [24, 48, 96, 256]);

  await convertToPNG(`${appIcon}-apple`, { width: 167, bg: appleBg });
  await convertToPNG(`${appIcon}-apple`, { width: 180, bg: appleBg });
  await convertToPNG(`${appIcon}-apple`, { width: 1024, bg: appleBg });

  await imagemin(
    [`${outRoot}/**/*.png`],
    `${outRoot}/`, {
    plugins: [
      imageminPngquant()
    ]
  });
})();

async function convertToPNG(name, options, maskable) {
  const width = options.width;
  const height = options.height || options.width;
  const output = options.output || `${outRoot}/build/${name}-${width}x${height}.png`;

  await convertFile(`./src/assets/${name}.svg`, {
    width,
    height,
    outputFilePath: output,
    background: options.bg
  });

  console.log(`created png ${output}`)

  if (maskable) {
    convertToPNG(name + '-maskable', options);
  }
}

async function convertToICO(name, sizes) {
  const files = sizes.map(size =>
    fs.readFileSync(`${outRoot}/build/${name}-${size}x${size}.png`),
  );

  const output = `${outRoot}/build/${name}.ico`;

  toIco(files).then(buf => {
    fs.writeFileSync(output, buf);
  });

  console.log(`created icon ${output}`)
}
