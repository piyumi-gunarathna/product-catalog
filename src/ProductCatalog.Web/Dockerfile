FROM node:16-alpine3.15 As builder
WORKDIR /usr/src/app
COPY ProductCatalog.Web/package.json ProductCatalog.Web/package-lock.json ./
COPY . .
WORKDIR /usr/src/app/ProductCatalog.Web
RUN rm ./src/assets/config.json
RUN npm install
RUN npm run build --prod
FROM nginx:1.15.8-alpine
COPY --from=builder /usr/src/app/ProductCatalog.Web/dist/product-catalog.web/ /usr/share/nginx/html