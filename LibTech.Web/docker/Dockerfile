FROM node:alpine

WORKDIR /app

COPY package.json ./
COPY package-lock.json ./
COPY aspnetcore-https.js ./
COPY aspnetcore-react.js ./
COPY ./ ./

RUN npm install

EXPOSE 3000

CMD ["npm", "start"]